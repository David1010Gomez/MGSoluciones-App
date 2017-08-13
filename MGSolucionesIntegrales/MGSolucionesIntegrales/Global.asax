<%@ Application Language="C#" %>
<%@ Import Namespace="MGSolucionesIntegrales" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        if (System.Web.HttpContext.Current.Session != null)
        {
               
            if (Session["Id_Rol"] == null)
            {
                Response.Redirect("Inicio_Sesion.aspx");
                //Response.Write(Session["Cedula"].ToString());
                //Response.Write(Session["Nombre"].ToString());
                //Response.Write(Session["Cargo"].ToString());
                //Response.Write(Session["Id_Rol"].ToString());

            }
        }
    }

</script>
