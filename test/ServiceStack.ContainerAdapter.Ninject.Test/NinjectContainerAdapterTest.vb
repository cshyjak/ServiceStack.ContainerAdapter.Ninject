Imports NUnit.Framework
Imports ServiceStack.ServiceClient.Web
Imports ServiceStack.Common.EnumerableExtensions

<TestFixture()> _
Public Class NinjectContainerAdapterTest
    Private _listeningOn = "http://localhost:8081/"
    Private _ninjectHost As NinjectAppHost

    <TestFixtureSetUp()> _
    Sub FixtureSetup()
        _ninjectHost = New NinjectAppHost()
        _ninjectHost.Init()
        _ninjectHost.Start(_listeningOn)
    End Sub

    <TestFixtureTearDown()> _
    Sub FixtureTearDown()
        If _ninjectHost IsNot Nothing Then
            _ninjectHost.Dispose()
            _ninjectHost = Nothing
        End If
    End Sub

    <Test()> _
    Sub Can_resolve_all_dependencies()
        Dim restClient As New JsonServiceClient(_listeningOn)

        Dim response = restClient.Get(Of NinjectServiceResponse)("ioc/")

        Dim expected As New List(Of String)
        expected.Add(GetType(CtorInjectableTester).Name)
        expected.Add(GetType(PropInjectableTester).Name)

        Assert.That(expected.EquivalentTo(response.Results))
    End Sub
End Class
