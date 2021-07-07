using DataAccessLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class CustomerService
    {
        #region Public Methods

        public List<Customer> GetCustomers(string name, string phoneNo, string tag, string website, string city)
        {
            using (var db = new DirectEmailerEntities())
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
                using (var db = new DirectEmailerEntities())
                {

                    Customer record = new Customer()
                    {
                        Name = name,
                        PhoneNo = phoneNo,
                        Tags = tags,
                        Email = email,
                        Website = website,
                        State = state,
                        City = city, 
                        CreatedDateTime = DateTime.Now
                    };

                    db.Customers.Add(record);
                    db.SaveChanges();

                    return record;
                }
            }
            else
            {
                using (var db = new DirectEmailerEntities())
                {
                    var record = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                    record.Name = name;
                    record.PhoneNo = phoneNo;
                    record.Tags = tags;
                    record.Email = email;
                    record.Website = website;
                    record.State = state;
                    record.City = city;
                    record.EditedDateTime = DateTime.Now;
                    db.SaveChanges(); 
                    return record;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DirectEmailerEntities())
            {
                var record = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                db.Customers.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteAll()
        {
            using (var db = new DirectEmailerEntities())
            {
                db.Database.ExecuteSqlCommand("delete from Customer");

                return true;
            }
        } 
        #endregion
    }
}
