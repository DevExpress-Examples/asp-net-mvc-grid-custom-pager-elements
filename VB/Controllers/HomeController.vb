Imports System
Imports System.Web.Mvc

Namespace T155783.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Return PartialView(NorthwindDataProvider.GetProducts())
		End Function

		Public Function GridViewCallbackPartial(ByVal pageSize? As Integer) As ActionResult
			ViewData("pageSize") = pageSize
			Return PartialView("GridViewPartial", NorthwindDataProvider.GetProducts())
		End Function

		Public Function FooterRowPartial() As ActionResult
			Return PartialView()
		End Function
	End Class
End Namespace
