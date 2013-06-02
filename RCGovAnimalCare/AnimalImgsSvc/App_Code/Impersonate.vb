Imports Microsoft.VisualBasic
Imports System.Security.Principal
Imports System.Runtime.InteropServices

Public Class ImpersonateUtil
    Implements IDisposable

    Private disposed As Boolean = False
    Private impersonated As Boolean = False

    Dim LOGON32_LOGON_INTERACTIVE As Integer = 2
    Dim LOGON32_PROVIDER_DEFAULT As Integer = 0

    Dim impersonationContext As WindowsImpersonationContext

    Declare Function LogonUserA Lib "advapi32.dll" (ByVal lpszUsername As String, _
                            ByVal lpszDomain As String, _
                            ByVal lpszPassword As String, _
                            ByVal dwLogonType As Integer, _
                            ByVal dwLogonProvider As Integer, _
                            ByRef phToken As IntPtr) As Integer

    Declare Auto Function DuplicateToken Lib "advapi32.dll" ( _
                            ByVal ExistingTokenHandle As IntPtr, _
                            ByVal ImpersonationLevel As Integer, _
                            ByRef DuplicateTokenHandle As IntPtr) As Integer

    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

    Sub New()

    End Sub

    Public Function Impersonate() As Boolean
        If Not impersonated Then
            Dim strUserName As String = ConfigurationManager.AppSettings.Item("username")
            Dim strDomain As String = ConfigurationManager.AppSettings.Item("domain")
            Dim strPassword As String = ConfigurationManager.AppSettings.Item("password")
            impersonated = ImpersonateValidUser(strUserName, strDomain, strPassword)
        End If

        Return impersonated
    End Function

    Public Sub UndoImpersonation()
        If impersonated Then
            impersonationContext.Undo()
        End If
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        If Not disposed Then
            If disposing Then
                UndoImpersonation()
            End If
        End If
        disposed = True
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub


    Private Function ImpersonateValidUser(ByVal userName As String, _
            ByVal domain As String, ByVal password As String) As Boolean

        Dim tempWindowsIdentity As WindowsIdentity
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero
        ImpersonateValidUser = False

        If RevertToSelf() Then
            If LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, _
                         LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                    tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                    impersonationContext = tempWindowsIdentity.Impersonate()
                    If Not impersonationContext Is Nothing Then
                        ImpersonateValidUser = True
                    End If
                End If
            End If
        End If
        If Not tokenDuplicate.Equals(IntPtr.Zero) Then
            CloseHandle(tokenDuplicate)
        End If
        If Not token.Equals(IntPtr.Zero) Then
            CloseHandle(token)
        End If
    End Function

End Class
