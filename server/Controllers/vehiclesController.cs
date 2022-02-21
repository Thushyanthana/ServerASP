using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using server.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace server.Controllers
{
    public class vehiclesController : ApiController
    {

        //Get Method
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            //select query for sql databse
            //if you want to do another table in same database you want to change only the sql command
            string query = @"select id,part_name,ShelveNumber,Location,PurchaseDate,AvailableQuantity,UnitPrice

                           from dbo.vehicles";

            //Before connection in web.config
            //connection
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["VehiclesAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))

            //The output from the select query will be available in the data adapter
            //Which will fill the data to the datatable
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        //Post Method
        public string Post(vehicles vp)
        {
            try
            {
                DataTable table = new DataTable();
                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"insert into  dbo.vehicles(part_name,ShelveNumber,Location,PurchaseDate,AvailableQuantity,UnitPrice)
values
(
'" + vp.part_name + @"'
,'" + vp.ShelveNumber + @"'
,'" + vp.Location + @"'
,'" + vp.PurchaseDate + @"'
,'" + vp.AvailableQuantity + @"'
,'" + vp.UnitPrice + @"'
)";

                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["VehiclesAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception  ex)
            {
                return "Failed to add";
            }

        }

        
        //Put Method
        public string Put(vehicles vt)
        {
            try
            {
                DataTable table = new DataTable();

                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"update  dbo.vehicles  set
part_name = '" + vt.part_name + @"'
,ShelveNumber='" + vt.ShelveNumber + @"'
,Location='" + vt.Location + @"'
,PurchaseDate='" + vt.PurchaseDate+ @"'
,AvailableQuantity='" + vt.AvailableQuantity + @"'
,UnitPrice='" + vt.UnitPrice + @"'
 where id=" + vt.id + @" ";

                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["VehiclesAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to update";
            }

        }



        //Delete method
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                //select query for sql databse
                //if you want to do another table in same database you want to change only the sql command
                string query = @"delete from  dbo.vehicles where id=" + id;


                //Before connection in web.config
                //connection
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["VehiclesAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))

                //The output from the select query will be available in the data adapter
                //Which will fill the data to the datatable
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Deleted to update";
            }

        }

    }
}
