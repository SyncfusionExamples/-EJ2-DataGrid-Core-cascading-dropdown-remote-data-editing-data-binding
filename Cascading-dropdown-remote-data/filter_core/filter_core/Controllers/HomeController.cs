﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using filter_core.Models;
using Syncfusion.EJ2.Base;

namespace TestSample.Controllers
{

    public class HomeController : Controller
    {

        public static List<States> state = new List<States>();
        public static List<Country> country= new List<Country>();
        public IActionResult Index()
        {
            var Order = OrdersDetails.GetAllRecords();
            ViewBag.DataSource = Order;
            
            return View();
        }

        
        public IActionResult StateDataSource([FromBody]ExtendedDataManager dm)
        {

            var state = States.getStates();
            
            var Data = state.ToList();
            int count = state.Count();


            List<States> iterateState= new List<States>();
            foreach (States st in state) {
                if (st.countryId == (Int64)dm.Where[0].value) {
                    iterateState.Add(st);
                }
            }            
            return dm.RequiresCounts ? Json(new { result = Data.Skip(dm.Skip).Take(dm.Take), count = count }) : Json(iterateState.ToList());
        }

        public IActionResult CountryDataSource([FromBody]ExtendedDataManager dm)
        {

            var country = Country.getCountries();
            var Data = country.ToList();
            int count = country.Count();

            return dm.RequiresCounts ? Json(new { result = Data.Skip(dm.Skip).Take(dm.Take), count = count }) : Json(Data);
        }

        public class ExtendedDataManager : DataManagerRequest
        {
            public IDictionary<string, string> @params;
        }



        public IActionResult UrlDatasource([FromBody]Data dm)
        {
            var order = OrdersDetails.GetAllRecords();
            var Data = order.ToList();
            int count = order.Count();
            return dm.requiresCounts ? Json(new { result = Data.Skip(dm.skip).Take(dm.take), count = count }) : Json(Data);
        }

        public ActionResult Update([FromBody]CRUDModel<OrdersDetails> value)
        {
            var ord = value.value;
            OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID == ord.OrderID).FirstOrDefault();
            val.OrderID = ord.OrderID;
            val.EmployeeID = ord.EmployeeID;
            val.CustomerID = ord.CustomerID;
            val.Freight = ord.Freight;
            val.OrderDate = ord.OrderDate;
            val.ShipCity = ord.ShipCity;

            return Json(value.value);
        }
        //insert the record
        public ActionResult Insert([FromBody]CRUDModel<OrdersDetails> value)
        {

            OrdersDetails.GetAllRecords().Insert(0, value.value);
            return Json(value.value);
        }
        //Delete the record
        public ActionResult CellEditDelete([FromBody]CRUDModel<OrdersDetails> value)
        {
            OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.OrderID == int.Parse(value.key.ToString())).FirstOrDefault());
            return Json(value);
        }

        public class Country
        { 
        public Country()
        {

        }

        public Country(int cid, string cname)
        {
                this.countryId = cid;
            this.countryName = cname;
        }
        public int countryId { get; set; }        
        public string countryName { get; set; }
        public static List<Country> getCountries()
        {             
            if (country.Count == 0)
            {
                    
                country.Add(new Country(1, "United States"));
               country.Add(new Country(2, "Australia"));             
            }                
                return country;
        }
    }


    public class States
        {

            public States() {

            }

            public States(int cid,int sid, string sname) {
                this.stateId= sid;
                this.countryId = cid;
                this.stateName = sname;
            }
            public int countryId { get; set; }
            public int stateId { get; set; }
            public string stateName { get; set; }
            public static List<States> getStates()
            {
                if (state.Count == 0)
                {
                    state.Add(new States(1, 101, "New York"));
                    state.Add(new States(1, 102, "Virginia"));
                    state.Add(new States(1, 103, "Washington"));
                    state.Add(new States(2, 104, "Queensland"));
                    state.Add(new States(2, 105, "Tasmania"));
                    state.Add(new States(2, 106, "Victoria"));
                }
                return state;
            }
        }
      

        public class Data
        {

            public bool requiresCounts { get; set; }
            public int skip { get; set; }
            public int take { get; set; }
            public Dictionary<string, object> @params { get; set; }
        }
        public class CRUDModel<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public object key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }
    }
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails()
        {

        }
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 10; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                    order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                    code += 5;
                }
            }
            return order;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }
}
