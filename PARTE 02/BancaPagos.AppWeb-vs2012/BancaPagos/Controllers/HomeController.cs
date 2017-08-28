using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BancaPagos.BE;
using BancaPagos.BL;

namespace BancaPagos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListBanco()
        {
            var lbanc = new BancoBL().findAll();
            return View(lbanc);
        }

        [HttpGet]
        public ActionResult CreateBanco()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanco(Banco b)
        {
            bool Exito = false;
            if (b.id_banca > 0)
                Exito = new BancoBL().edit(b);
            else
                Exito = new BancoBL().insert(b);

            if (Exito)
                ViewBag.Messageresult = "Se guardo correctamente!";

            return View();
           
        }

        [HttpGet]
        public ActionResult EditBanco(int id)
        {
            var lbanc = new BancoBL().find(id);
            return View(lbanc);
        }

      
        [HttpGet]
        public ActionResult ListSucursal(string pnombre)
        {
            var lsuc = new SucursalBL().findAll(pnombre);
            return View(lsuc);
        }

        [HttpGet]
        public ActionResult CreateSucursal()
        {
            var lbanco = new BancoBL().findAll();
            var obj = new Sucursal();
            obj.ListaBanco = new  BancoBL().findAll();
         
            return View(obj);
        }

        [HttpPost]
        public ActionResult CreateSucursal(Sucursal s)
        {   
            if (s.id_sucursal > 0)
                new SucursalBL().edit(s);
            else
                new SucursalBL().insert(s);

       
            return Redirect("ListSucursal?pnombre=-1");
        }


        [HttpGet]
        public ActionResult EditSucursal(int id, int idbanco)
        {
            var lsuc = new SucursalBL().find(id);
            var lbanco = new BancoBL().findAll();
            SelectList litem = new SelectList(lbanco, "id_banca", "Nombre", idbanco);
            ViewBag.DropDownList_Banco = litem;

            return View(lsuc);
        }



        [HttpGet]
        public ActionResult ListOrdenPago(string pbanco, string psucursal)
        {
            var lop = new OrdenPagoBL().findAll(pbanco, psucursal);
            return View(lop);

            
        }

        public JsonResult GetSucursal(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var data = new SucursalBL().findAllById(id);

            foreach (var i in data) {
                list.Add(new SelectListItem { Text = i.Nombre, Value = i.id_sucursal.ToString() });
            }
            return Json(new SelectList(list.ToList(), "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

    
        [HttpGet]
        public ActionResult CreateOrdenPago()
        {
            var lbanco = new BancoBL().findAll();
            SelectList litem = new SelectList(lbanco, "id_banca", "Nombre");
            ViewBag.DropDownList_Banco = litem;


            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "PAGADO", Value = "PAGADO" });
            li.Add(new SelectListItem() { Text = "DECLINADO", Value = "DECLINADO" });
            li.Add(new SelectListItem() { Text = "FALLIDA", Value = "FALLIDA" });
            li.Add(new SelectListItem() { Text = "ANULADA", Value = "ANULADA" });

            SelectList listestado = new SelectList(li, "Value", "Text");

            ViewBag.DropDownList_Estado = listestado;

            List<SelectListItem> lmoney = new List<SelectListItem>();
            lmoney.Add(new SelectListItem() { Text = "SOLES", Value = "SOLES" });
            lmoney.Add(new SelectListItem() { Text = "DOLARES", Value = "DOLARES" });

            SelectList listmoneda = new SelectList(lmoney, "Value", "Text");
            ViewBag.DropDownList_Moneda = listmoneda;



            return View();
        }

        [HttpPost]
        public ActionResult CreateOrdenPago(FormCollection form)
        {
            string vMoneda = form["ddlMoneda"].ToString();
            int vSucursal = Convert.ToInt32(form["ddlSucursal"]);
            string vEstado = form["ddlEstado"].ToString();
            string vMonto = form["Monto"].ToString();

            OrdenPago objO = new OrdenPago();
            objO.id_sucursal = vSucursal;
            objO.Moneda = vMoneda;
            objO.Estado = vEstado;

           if (!string.IsNullOrEmpty(vMonto)){
                objO.Monto = Convert.ToDecimal(vMonto);
            }
            

            var Exito = new OrdenPagoBL().insert(objO);
         

            return Redirect("ListOrdenPago?pbanco=-1&psucursal=-1");
        }
             


        [HttpGet]
        public ActionResult EditOrdenPago(string id, string pestado, string moneda)
        {
            
            OrdenPago opb;           
            opb = new OrdenPagoBL().find(Convert.ToInt32(id));
           
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem() { Text = "PAGADO", Value = "PAGADO" });
                li.Add(new SelectListItem() { Text = "DECLINADO", Value = "DECLINADO" });
                li.Add(new SelectListItem() { Text = "FALLIDA", Value = "FALLIDA" });
                li.Add(new SelectListItem() { Text = "ANULADA", Value = "ANULADA" });

                SelectList litem = new SelectList(li, "Value", "Text", pestado.Trim());

                ViewBag.DropDownList_Estado = litem;


                List<SelectListItem> lmoney = new List<SelectListItem>();
                lmoney.Add(new SelectListItem() { Text = "SOLES", Value = "SOLES" });
                lmoney.Add(new SelectListItem() { Text = "DOLARES", Value = "DOLARES" });

                SelectList listm = new SelectList(lmoney, "Value", "Text", moneda.Trim());

                ViewBag.DropDownList_Moneda = listm;

                return View(opb);   
           
        }


        [HttpPost]
        public ActionResult SaveOrdenPago(FormCollection form)
        {

           
            string strMoneda = form["ddlMoneda"].ToString();
            int id_sucursal = Convert.ToInt32(form["id_sucursal"]);
            string strEstado = form["ddlEstado"].ToString();
            int id_ordenPago = Convert.ToInt32(form["id_ordenPago"]);
            string Monto = form["Monto"].ToString();

            OrdenPago objO = new OrdenPago();
            objO.id_ordenPago = id_ordenPago;
            objO.id_sucursal = id_sucursal;
            objO.Moneda = strMoneda;
            objO.Estado = strEstado;
            objO.Monto = Convert.ToDecimal(Monto);

            var Exito = new OrdenPagoBL().edit(objO);

            return Redirect("ListOrdenPago?pbanco=-1&psucursal=-1");

        }

        


    }
}
