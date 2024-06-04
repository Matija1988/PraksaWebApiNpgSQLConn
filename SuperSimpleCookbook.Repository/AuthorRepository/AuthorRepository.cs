﻿using Npgsql;
using SuperSimpleCookbook.Model;
using SuperSimpleCookbook.Repository.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleCookbook.Repository.AuthorRepository
{
    public class AuthorRepository : IRepositoryAuthor<Author>
    {
       
        private readonly NpgsqlConnection _connection;
        public AuthorRepository()
        {
            _connection = new NpgsqlConnection("Host=localhost;Port=5432; User Id=postgres; Password=root;Database=Kuharica;");
        }
        public async Task<bool> Delete(int id)
        {
            return false;
        }

        public async Task<Author> Get(Guid uuid)
        {
            string commandText = "SELECT \"FirstName\", \"LastName\"  FROM \"Author\" WHERE \"Uuid\" = @uuid;";

            var command = new NpgsqlCommand(commandText, _connection);

            command.Parameters.AddWithValue("@Uuid", NpgsqlTypes.NpgsqlDbType.Uuid, uuid);

            await _connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    var author = new Author
                    {

                        FirstName = reader.GetString(0),
                        LastName = reader.GetString(1),

                    };

                    await _connection.CloseAsync();
                    await _connection.DisposeAsync();
                    return author;

                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Author>> GetAll()
        {
            try
            {
                string commandText = "SELECT * FROM \"Author\" where \"IsActive\" = true;";
                var listFromDB = new List<Author>();
                var command = new NpgsqlCommand(commandText, _connection);

                await _connection.OpenAsync();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listFromDB.Add(new Author
                    {

                        Id = reader.GetInt32(0),
                        Uuid = reader.GetGuid(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        DateOfBirth = reader.GetDateTime(4),
                        Bio = reader.GetString(5),
                        IsActive = reader.GetBoolean(6),
                        DateCreated = reader.GetDateTime(7),
                        DateUpdated = reader.GetDateTime(8),

                    });
                }

                await _connection.CloseAsync();
                await reader.DisposeAsync();

                return listFromDB;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<Author>> GetNotActive()
        {
            string commandText = "SELECT * FROM \"Author\" where \"IsActive\" = false;";
            var listFromDB = new List<Author>();
            var command = new NpgsqlCommand(commandText, _connection);

            await _connection.OpenAsync();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                listFromDB.Add(new Author
                {

                    Id = reader.GetInt32(0),
                    Uuid = reader.GetGuid(1),
                    FirstName = reader.GetString(2),
                    LastName = reader.GetString(3),
                    DateOfBirth = reader.GetDateTime(4),
                    Bio = reader.GetString(5),
                    IsActive = reader.GetBoolean(6),
                    DateCreated = reader.GetDateTime(7),
                    DateUpdated = reader.GetDateTime(8)


                });
            }
            if(listFromDB is null)
            {
                return null;
            }

            await _connection.CloseAsync();
            await reader.DisposeAsync();

            return listFromDB;
        }

        public async Task<Author> Post(Author item)
        {
            return null;
        }

        public async Task<Author> Put(Author item, int id)
        {
            return null;
        }
    }
}