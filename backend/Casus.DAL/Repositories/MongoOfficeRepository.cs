using Casus.Core.Interfaces;
using Casus.Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Casus.DAL.Mongo.Repositories
{
    public class MongoOfficeRepository : IOfficeRepository
    {
        private readonly IMongoDatabase database;

        public MongoOfficeRepository(IOptions<MongoConnection> connection)
        {
            database = new MongoClient(connection.Value.ConnectionString).GetDatabase(connection.Value.Database);
        }

        public IMongoCollection<Office> OfficeCollection
        {
            get
            {
                return database.GetCollection<Office>("Office");
            }
        }

        public void AddEmployee(Guid officeId, Employee employee)
        {
            var filter = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Push("Employees", employee);
            OfficeCollection.UpdateOne(filter, update);
        }

        public void AddReservationToRoom(Guid officeId, List<Room> rooms)
        {
            var filterOffice = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Set("Rooms", rooms);
            OfficeCollection.UpdateOne(filterOffice, update);
        }

        public void AddResourceToReservation(Guid officeId, List<Room> rooms)
        {
            var filterOffice = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Set("Rooms", rooms);
            OfficeCollection.UpdateOne(filterOffice, update);
        }

        public void AddResourceToRoom(Guid officeId, List<Room> rooms)
        {
            var filterOffice = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Set("Rooms", rooms);
            OfficeCollection.UpdateOne(filterOffice, update);
        }

        public void AddRoom(Guid officeId, Room room)
        {
            var filter = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Push("Rooms", room);
            OfficeCollection.UpdateOne(filter, update);
        }

        public Office CreateOffice(Office office)
        {
            OfficeCollection.InsertOne(office);
            return office;
        }

        public List<Office> GetAllOffices()
        {
            var filter = Builders<Office>.Filter.Empty;
            var offices = OfficeCollection.Find(filter).ToList();
            return offices;
        }

        public Office GetOfficeById(Guid id)
        {
            var filter = Builders<Office>.Filter.Eq("Id", id);
            var office = OfficeCollection.Find(filter).First();
            return office;
        }

        public void RemoveResourceFromRoom(Guid officeId, List<Room> rooms)
        {
            var filterOffice = Builders<Office>.Filter.Eq("Id", officeId);
            var update = Builders<Office>.Update.Set("Rooms", rooms);
            OfficeCollection.UpdateOne(filterOffice, update);
        }
    }
}
