using NetEmail.Entity;
using NetMail.Entity;
using NetMail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMail.Business
{
    class CustomerBusiness : Singleton<CustomerBusiness>
    {
        #region Constructor

        public CustomerBusiness()
        {
            CheckTables();
        }

        private void CheckTables()
        {
            if (IsTableExists("Customer") == false)
            {
                using (var db = new NetEmailContext())
                {
                    db.Database.ExecuteSqlCommand(@"
                    create table Customer 
                    (
                        Id INTEGER AUTO INCREMENT PRIMARY KEY, 
                        Name VARCHAR NOT NULL,
                        Surname INTEGER NULL, 
                        Tags VARCHAR NOT NULL,
                        Email VARCHAR NOT NULL
                    )
                    ");
                }
            }
            else
            {
                try
                {
                    using (var db = new NetEmailContext())
                    {
                        if (!IsColumnExists("PhoneNo"))
                        {
                            db.Database.ExecuteSqlCommand(@"
                               ALTER TABLE Customer
                               ADD PhoneNo VARCHAR;
                             ");
                        }
                        if (!IsColumnExists("Website"))
                        {
                            db.Database.ExecuteSqlCommand(@"
                             ALTER TABLE Customer
                              ADD Website VARCHAR;
                             ");
                        }

                        if (!IsColumnExists("City"))
                        {
                            db.Database.ExecuteSqlCommand(@"
                             ALTER TABLE Customer
                              ADD City VARCHAR;
                             ");
                        }

                        if (!IsColumnExists("State"))
                        {
                            db.Database.ExecuteSqlCommand(@"
                             ALTER TABLE Customer
                              ADD State VARCHAR;
                             ");
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        private bool IsTableExists(String tableName)
        {
            using (var db = new NetEmailContext())
            {
                int a = db.Database.SqlQuery<int>(
                    "select count(*) from sqlite_master where type = 'table' and name = {0}",
                    tableName)
                    .FirstOrDefault();

                if (a > 0) return true;
                else return false;
            }
        }
        private bool IsColumnExists(string columName)
        {
            using (var db = new NetEmailContext())
            {
                int a = db.Database.SqlQuery<int>(
                    "SELECT COUNT(*) AS CNTREC FROM pragma_table_info('Customer') WHERE name='" + columName + "'")
                    .FirstOrDefault();

                if (a > 0) return true;
                else return false;
            }
        }

        #endregion

        #region Public Methods

        public List<Customer> GetCustomers(string name, string phoneNo, string tag, string website, string city)
        {
            using (var db = new NetEmailContext())
            {
                var query = db.Customers.AsQueryable();

                if (string.IsNullOrEmpty(name) == false) query = query.Where(q => q.Name.Contains(name));
                if (string.IsNullOrEmpty(phoneNo) == false) query = query.Where(q => q.PhoneNo.Contains(phoneNo));
                if (string.IsNullOrEmpty(website) == false) query = query.Where(q => q.Website.Contains(website));
                if (string.IsNullOrEmpty(city) == false) query = query.Where(q => q.City.Contains(city));
                if (string.IsNullOrEmpty(tag) == false) query = query.Where(q => q.Tags.Contains(tag + "|"));

                var result = query.ToList();

                return result;

            }
        }

        public Customer Save(int id, string name, string phoneNo, string tags, string email, string website, string state, string city)
        {
            if (string.IsNullOrEmpty(tags)) throw new Exception("Please enter a tag for customer: " + name);

            if (tags.Last() != '|') tags += '|';

            if (id == 0)
            {
                using (var db = new NetEmailContext())
                {
                    int maxId = 0;
                    if (db.Customers.Count() > 0)
                    {
                        maxId = db.Customers.Max(x => x.Id);
                    }

                    Customer record = new Customer()
                    {
                        Id = maxId + 1,
                        Name = name,
                        PhoneNo = phoneNo,
                        Tags = tags,
                        Email = email,
                        Website = website,
                        State = state,
                        City = city
                    };

                    db.Customers.Add(record);
                    db.SaveChanges();

                    return record;
                }
            }
            else
            {
                using (var db = new NetEmailContext())
                {
                    var record = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                    record.Name = name;
                    record.PhoneNo = phoneNo;
                    record.Tags = tags;
                    record.Email = email;
                    record.Website = website;
                    record.State = state;
                    record.City = city;
                    db.SaveChanges();

                    return record;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new NetEmailContext())
            {
                var record = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                db.Customers.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteAll()
        {
            using (var db = new NetEmailContext())
            {
                db.Database.ExecuteSqlCommand("delete from Customer");

                return true;
            }
        }

        #endregion
    }
}
