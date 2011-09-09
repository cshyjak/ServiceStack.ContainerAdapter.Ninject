Imports Ninject
Imports Ninject.Parameters
Imports ServiceStack.ServiceHost
Imports ServiceStack.Configuration

Public Class NinjectContainerAdapter
    Implements IContainerAdapter

    Private _kernel As ikernel

    Sub New(kernel As IKernel)
        _kernel = kernel
    End Sub

    Public Function Resolve(Of T)() As T Implements Configuration.IContainerAdapter.Resolve
        Return _kernel.Get(Of T)()
    End Function

    Public Function TryResolve(Of T)() As T Implements Configuration.IContainerAdapter.TryResolve
        If _kernel.CanResolve(_kernel.CreateRequest(GetType(T), Function(x) True, New List(Of IParameter), False, False)) Then
            Return _kernel.Get(Of T)()
        Else
            Return Nothing
        End If
    End Function
End Class
