Imports ServiceStack.ServiceHost
Imports ServiceStack.ServiceInterface.ServiceModel

Public Class NinjectService
    Implements IService(Of Ninject), IRequiresRequestContext

    Private _ctorDep As ICtorInjectable

    Public Property RequestContext As IRequestContext Implements IRequiresRequestContext.RequestContext
    Public Property PropInjectable As IPropInjectable

    Public Function Execute(request As Ninject) As Object Implements IService(Of Ninject).Execute
        Dim response As New NinjectServiceResponse

        response.Results.Add(_ctorDep.GetType().Name)
        response.Results.Add(PropInjectable.GetType().Name)

        Return response
    End Function

    Sub New(ctorInjectable As ICtorInjectable)
        _ctorDep = ctorInjectable
    End Sub
End Class

Public Class Ninject

End Class

Public Class NinjectServiceResponse
    Implements IHasResponseStatus

    Public Property ResponseStatus As ResponseStatus Implements IHasResponseStatus.ResponseStatus
    Public Property Results As IList(Of String)

    Sub New()
        ResponseStatus = New ResponseStatus()
        Results = New List(Of String)()
    End Sub
End Class