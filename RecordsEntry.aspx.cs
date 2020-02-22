using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace COVID19GuestWeb
{
    public partial class RecordsEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDDL();
                ddlLocationLevel_SelectedIndexChanged(null, null);
            }
        }



        protected void ddlLocationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocationName.Items.Clear();
            using (var context = new COVID19Entities())
            {
                var selectedLevel = Byte.Parse(ddlLocationLevel.SelectedValue);
                var rooms = context.Locations.Where(x => x.LocationFloor == selectedLevel).Select(x => x.LocationName);
                foreach (var item in rooms)
                {
                    ddlLocationName.Items.Add(item);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var context = new COVID19Entities())
            {
                var getLocationID = (from x in context.Locations
                                     where x.LocationName == ddlLocationName.SelectedValue
                                     select x.ID).FirstOrDefault();
                var getLatestID = (from x in context.ContactTracings
                                   orderby x.ID descending
                                   select x.ID).FirstOrDefault() + 1;
                if (Decimal.Parse(tbTemp.Text) > 38)
                {
                    MessageBox.Show("Your Temperature is above the 38 degrees celsius threshold", "Temperature", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                context.ContactTracings.Add(new ContactTracing()
                {
                    ID = getLatestID,
                    Contact = tbContact.Text,
                    Email = tbEmail.Text,
                    FullName = tbFullName.Text,
                    LocationID = getLocationID,
                    Temp = Decimal.Parse(tbTemp.Text),
                    RegisterDateTime = DateTime.Now
                });
                context.SaveChanges();
                MessageBox.Show("Record submitted successfully", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearEntries();
            }
        }
        private void loadDDL()
        {
            using (var context = new COVID19Entities())
            {
                foreach (var item in context.Locations.Select(x => x.LocationFloor).Distinct())
                {
                    ddlLocationLevel.Items.Add(item.ToString());
                }
            }

        }
        private void ClearEntries()
        {
            tbFullName.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbTemp.Text = string.Empty;
            tbContact.Text = string.Empty;
        }
    }
}