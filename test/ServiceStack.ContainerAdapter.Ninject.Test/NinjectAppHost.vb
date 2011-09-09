Imports Ninject
Imports ServiceStack.WebHost.EndPoints

Public Class NinjectAppHost
    Inherits AppHostHttpListenerBase

    Sub New()
        MyBase.new("NinjectApp Service", GetType(NinjectService).Assembly)
    End Sub

    Public Overrides Sub Configure(container As Funq.Container)
        Dim kernel As IKernel = New StandardKernel(New NinjectTestModule)

        container.Adapter = New NinjectContainerAdapter(kernel)

        Routes.Add(Of Ninject)("/ioc")
    End Sub
End Class
