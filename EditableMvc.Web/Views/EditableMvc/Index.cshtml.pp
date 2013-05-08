@using $rootnamespace$
@{
    ViewBag.Title = "title";
    Layout = "~/Views/Shared/_EditableMvcLayout.cshtml"; ;
}


<div id="header">@Html.EditableMvc("h1", "HeaderDemo", null, "Click to edit me!")</div>
  <div id="wrapper">
      <div id="content">
          @Html.EditableMvc("p", "DemoContentHeader", null, "<strong>Content header.</strong>")
         @Html.EditableMvc("p", "DemoContentPar1", null, "Vivamus egestas dignissim risus id viverra. Donec quis lacus lacus, ut varius mi. Ut at nulla neque. Ut at mauris vitae turpis facilisis lacinia")
        @Html.EditableMvc("p", "DemoContentPar2", null, "Donec viverra scelerisque augue accumsan placerat. Maecenas adipiscing lorem id ipsum convallis nec ullamcorper dui venenatis")
    </div>
  </div>
  <div id="navigation">
    @Html.EditableMvc("p", "DemoInfoHeader", null, "<strong>Info header.</strong>")
      <ul>
           <li>@Html.EditableMvc("div", "DemoNavigationItem1", null, "Suspendisse feugiat adipiscing tincidunt. Nunc vulputate tristique libero fermentum auctor. Ut consectetur dui at nulla aliquet porta")</li>
      </ul>
  </div>
  <div id="extra">
      <p>@Html.EditableMvc("div", "DemoParagraphHeader", null, "<strong>Edit my content and me too.</strong>")</p>
      @Html.EditableMvc("p", "DemoParagraph", new { @class = "something" }, "sit malesuada lacus pellus parturpiscing. Pellenterdumat maecenatoque cras a magna nibh et quis diam ames et. Laoremvolutpat ac dolor eget eget temper lacus vestibus velit lacus venean")
    
  </div>
  <div id="footer">
      @Html.EditableMvc("p", "DemoFooter", null, "Editable footer")
  </div>


