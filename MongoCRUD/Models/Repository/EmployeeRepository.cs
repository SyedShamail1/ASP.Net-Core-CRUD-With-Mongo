using MongoCRUD.IRepository;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoCRUD.Models.Repository
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _employeeTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("your mongo connection id");//i.emongodb://127.0.0.1:27017
            _database = _mongoClient.GetDatabase("");//YOur db name in mongo i.e EmployeeDemo
            _employeeTable = _database.GetCollection<Employee>("");//The collection you want to get. i.e Employee

        }
        public string Delete(string id)
        {
            _employeeTable.DeleteOne(x => x.Id == id);
            return "Deleted";
        }

        public Employee Get(string id)
        {
            return _employeeTable.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
        }

        public Employee Save(Employee entity)
        {
            var empObj = _employeeTable.Find(x => x.Id == entity.Id).FirstOrDefault();
            if(empObj == null)
            {
                _employeeTable.InsertOne(entity);
            }
            else
            {
                _employeeTable.ReplaceOne(x => x.Id == entity.Id, entity);
            }
            return entity;
        }
    }
}
