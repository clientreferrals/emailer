using DataAccessLayer.DataBase;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusniessLayer
{
    public class CustomerService
    {
        #region Public Methods

        public List<CustomerDto> GetCustomers(string name, string phoneNo, string tag, string website, string city)
        {
            using (var db = new DirectEmailContext())
            {
                var query = db.Customers.AsQueryable();

                if (string.IsNullOrEmpty(name) == false)
                {
                    query = query.Where(q => q.Name.Contains(name));
                }
                if (string.IsNullOrEmpty(phoneNo) == false)
                {
                    query = query.Where(q => q.PhoneNo.Contains(phoneNo));
                }
                if (string.IsNullOrEmpty(website) == false)
                {
                    query = query.Where(q => q.Website.Contains(website));

                }
                if (string.IsNullOrEmpty(city) == false)
                {
                    query = query.Where(q => q.City.Contains(city));
                }
                if (string.IsNullOrEmpty(tag) == false)
                {
                    query = query.Where(q => q.Tags.Contains(tag));
                }

                var result = query.Select(
                    x => new CustomerDto()
                    {
                        Id = x.Id,
                        Email = x.Email,
                        Name = x.Name,
                        City = x.City,
                        PhoneNo = x.PhoneNo,
                        Website = x.Website,
                        Tags = x.Tags,
                        State = x.State,
                        ZipCode = x.zipCode,
                        CreatedDateTime = x.CreatedDateTime,
                        EditedDateTime = x.EditedDateTime,
                    }).ToList();

                return result;

            }
        }

        public bool Save(string name, string phoneNo, string tags, string email, string website, string state, string city, string zipCode)
        {
            if (string.IsNullOrEmpty(tags)) throw new Exception("Please enter a tag for customer: " + name);

            
            using (var db = new DirectEmailContext())
            {
                var record = db.Customers.Where(x => x.Email == email).FirstOrDefault();
                if (record == null)
                {
                    record = new Customer()
                    {
                        Name = name,
                        PhoneNo = phoneNo,
                        Tags = tags,
                        Email = email,
                        Website = website,
                        State = state,
                        City = city,
                        zipCode = zipCode,
                        CreatedDateTime = DateTime.Now
                    };

                    db.Customers.Add(record);
                    db.SaveChanges();

                    return true;

                }
                else
                {
                    record.Name = name;
                    record.PhoneNo = phoneNo;
                    record.Tags = tags;
                    record.Email = email;
                    record.Website = website;
                    record.State = state;
                    record.City = city;
                    record.EditedDateTime = DateTime.Now;
                    record.zipCode = zipCode;
                    db.SaveChanges();
                    return true;

                }
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DirectEmailContext())
            {
                var record = db.Customers.Where(x => x.Id == id).FirstOrDefault();

                db.Customers.Remove(record);
                db.SaveChanges();

                return true;
            }
        }

        public bool DeleteAll()
        {
            using (var db = new DirectEmailContext())
            {
                db.Database.ExecuteSqlCommand("delete from Customer");

                return true;
            }
        }
        #endregion
    }
}
