using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.MicroKernel;
using Castle.MicroKernel.ComponentActivator;
using GoFishing.Application.Services;


namespace GoFishing.Presentation
{
   
    public partial class PropertyInjection : System.Web.UI.Page
    {
        [Wire]
        public  IFishingService FishingService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreInit(EventArgs e)
        {
            Global.Container.Kernel.InjectProperties(this);
            base.OnPreInit(e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = FishingService.GetTrips();
        }
    }
}