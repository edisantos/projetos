using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using RefaccoSystem.Refacco.Models;
using BLL.EntradaBusiness;
using System.Web.UI.WebControls;

namespace RefaccoSystem.Refacco.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetPlant();
            }
           
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, TurnoId =ddlTurno.SelectedItem.Text ,PlantaId = ddlPlanta.SelectedItem.Text,funcao = ddlFunction.SelectedItem.Text,predio =ddlPredio.SelectedItem.Text,Area = ddlArea.SelectedItem.Text};
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirme sua conta", "Confirme sua conta clicando <a href=\"" + callbackUrl + "\">aqui</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
               
                StatusMessage.Text = string.Format("user {0} was created sucessfully!",user.UserName);
                GetPlant();
                ddlTurno.SelectedValue = "0";
                Email.Text = string.Empty;
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        public void GetPlant()
        {
            try
            {
                var listPlanta = new DropboxGenericos();
                ddlPlanta.DataSource = listPlanta.FilterPlant();
                ddlPlanta.DataTextField = "Planta";
                ddlPlanta.DataValueField = "PlantaId";
                ddlPlanta.DataBind();
                ListItem item = new ListItem("SELECT PLANT", "VALUES", true);item.Selected = true;
                ddlPlanta.Items.Add(item);
                   
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}