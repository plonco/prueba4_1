using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVistas.Models;

namespace WebVistas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<asignacion> Asignacion = obtenerAsignacion();

            return View(Asignacion);
        }
        public ActionResult Create()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
  
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            //Buscar el id y crear un objeto Empleado
            asignacion a = buscarRut(id);

            return View(a);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(string id)
        {
            asignacion asi = buscarRut(id);
            return View(asi);
        }

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                eliminarAsignacion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void agregar()
        {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("insert into asignacion values ()", cnn);


                SqlDataReader dr = cmdSql.ExecuteReader();

                cnn.Close();
                cnn.Dispose();
            }
        }


        private List<asignacion> obtenerAsignacion()
        {
            List<asignacion> Asignacion = new List<asignacion>();
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from asignacion", cnn);

                SqlDataReader dr = cmdSql.ExecuteReader();

                while (dr.Read())
                {
                    Asignacion.Add(new asignacion(dr["rut"].ToString(), dr["nombre"].ToString(), dr["apellido"].ToString(), dr.GetInt32(3), dr.GetInt32(4)));
                }

                cnn.Close();
                cnn.Dispose();
            }

            return Asignacion;
        }

        private asignacion buscarRut(string id)
        {
            asignacion asignacions = null;
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from asignacion where rut = @id", cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmdSql.ExecuteReader();

                if (dr.Read())
                {
                    asignacions = new asignacion(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3), dr.GetInt32(4));
                }


                cnn.Close();
                cnn.Dispose();
            }

            return asignacions;
        }


        private int eliminarAsignacion(string id)
        {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("delete from asignacion where rut = @id", cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                return cmdSql.ExecuteNonQuery();

            }
        }



    }
}