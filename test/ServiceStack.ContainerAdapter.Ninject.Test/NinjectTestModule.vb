Imports Ninject.Modules

Public Class NinjectTestModule
    Inherits NinjectModule

    Public Overrides Sub Load()
        Bind(Of ICtorInjectable).To(Of CtorInjectableTester)()
        Bind(Of IPropInjectable).To(Of PropInjectableTester)()
    End Sub
End Class
