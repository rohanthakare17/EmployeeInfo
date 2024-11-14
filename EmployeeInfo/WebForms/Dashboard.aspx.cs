using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EmployeeInfo.WebForms
{
    public partial class Dashboard : System.Web.UI.Page
    {


        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string imagePath = string.Empty;
            if (fileImage.HasFile)
            {
                imagePath = "~/Images/" + fileImage.FileName;
                fileImage.SaveAs(Server.MapPath(imagePath));
            }

            string query = "INSERT INTO Users (Name, DateOfBirth, Sex, Phone, Address, Image) VALUES (@Name, @DOB, @Sex, @Phone, @Address, @Image)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.Parameters.AddWithValue("@Sex", ddlSex.SelectedValue);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Image", imagePath);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Record added successfully.";
                lblMessage.Visible = true;
                LoadData();
            }
        }

        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvData.SelectedRow;
            txtName.Text = row.Cells[1].Text;
            txtDOB.Text = DateTime.Parse(row.Cells[2].Text).ToString("yyyy-MM-dd");
            ddlSex.SelectedValue = row.Cells[3].Text;
            txtPhone.Text = row.Cells[4].Text;
            txtAddress.Text = row.Cells[5].Text;
            ViewState["SelectedID"] = row.Cells[0].Text;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["SelectedID"] != null)
            {
                string imagePath = string.Empty;
                if (fileImage.HasFile)
                {
                    imagePath = "~/Images/" + fileImage.FileName;
                    fileImage.SaveAs(Server.MapPath(imagePath));
                }

                string query = "UPDATE Users SET Name = @Name, DateOfBirth = @DOB, Sex = @Sex, Phone = @Phone, Address = @Address, Image = @Image WHERE ID = @ID";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", ViewState["SelectedID"]);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                    cmd.Parameters.AddWithValue("@Sex", ddlSex.SelectedValue);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Image", imagePath);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Record updated successfully.";
                    lblMessage.Visible = true;
                    LoadData();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ViewState["SelectedID"] != null)
            {
                string query = "DELETE FROM Users WHERE ID = @ID";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", ViewState["SelectedID"]);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Record deleted successfully.";
                    lblMessage.Visible = true;
                    LoadData();
                }
            }
        }

    }
}