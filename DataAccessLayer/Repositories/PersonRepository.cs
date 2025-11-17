using CoreLayer.Configurations;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IPerson;
using DataAccessLayer.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        private readonly ILoggerManager _loggerManager;
        private readonly AppDbContext _context;

        public PersonRepository(IOptions<DatabaseSettings> options, ILoggerManager loggerManager, AppDbContext context)
        {
            _connectionString = options.Value.ConnectionString;
            _loggerManager = loggerManager;
            _context = context;
        }

        /// <summary>
        /// Maps a data reader row to a Person entity.
        /// </summary>
        private Person MapReaderToPerson(SqlDataReader reader)
        {
            return new Person
            {
                PersonID = (int)reader["PersonID"],
                FirstName = (string)reader["FirstName"],
                MiddleName = reader["MiddleName"] == DBNull.Value ? null : (string)reader["MiddleName"],
                LastName = (string)reader["LastName"],
                DateOfBirth = (DateTime)reader["DateOfBirth"],
                Gender = (bool)reader["Gender"],
                Email = reader["Email"] == DBNull.Value ? null : (string)reader["Email"],
                ImageName = reader["ImageName"] == DBNull.Value ? null : (string)reader["ImageName"],
            };
        }
        /// <summary>
        /// Maps a data reader row to a PhoneNumber entity.
        /// </summary>
        private PhoneNumber MapReaderToPhoneNumber(SqlDataReader reader)
        {
            return new PhoneNumber
            {
                PhoneNumberID = reader["PhoneNumberID"] is int id ? id : 0,
                PersonID = reader["PersonID"] is int pid ? pid : 0,
                Number = reader["PhoneNumber"]?.ToString() ?? string.Empty
            };
        }

        /// <summary>
        /// Retrieves all people and their phone numbers.
        /// </summary>
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var people = new Dictionary<int, Person>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("SP_GetPeopleWithPhoneNumbers", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int personId = (int)reader["PersonID"];

                            if (!people.ContainsKey(personId))
                                people.Add(personId, MapReaderToPerson(reader));

                            if (reader["PhoneNumber"] != DBNull.Value && reader["PhoneNumberID"] != DBNull.Value)
                            {
                                people[personId].PhoneNumbers.Add(MapReaderToPhoneNumber(reader));
                            }

                        }

                    }

                }
                return people.Values.ToList();

            }
            
        }

        public async Task<Person?> GetByIdAsync(int personID)
        {
            

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetPersonWithPhoneNumbersByID", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            Person? person = null;

                            while (await reader.ReadAsync())
                            {
                                if (person == null)
                                 person =  MapReaderToPerson(reader);

                                if (reader["PhoneNumber"] != DBNull.Value && reader["PhoneNumberID"] != DBNull.Value)
                                {
                                    person.PhoneNumbers.Add(MapReaderToPhoneNumber(reader));
                                }
                            }
                             return person;
                        }
                    }
                }
                
            
        }

        public async Task<bool> ExistsAsync(int personID)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsPersonExist", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);

                    await connection.OpenAsync();

                    object? result = await command.ExecuteScalarAsync();
                    
                    return result != null && result != DBNull.Value;
                }
            }
                
        }

        public async Task<int> AddAsync(Person person)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddPerson", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", (object?)person.MiddleName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", person.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", person.Gender);
                    command.Parameters.AddWithValue("@Email", (object?)person.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageName", (object?)person.ImageName ?? DBNull.Value);

                    // باراميتر الإخراج
                    SqlParameter outPutIdParam = new SqlParameter("@PersonID", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    command.Parameters.Add(outPutIdParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    return (int)outPutIdParam.Value;
                }
            }
        
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", person.PersonID);
                    command.Parameters.AddWithValue("@FirstName", person.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", (object?)person.MiddleName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", person.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", person.Gender);
                    command.Parameters.AddWithValue("@Email", (object?)person.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageName", (object?)person.ImageName ?? DBNull.Value);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }

        }

        public async Task<bool> DeleteAsync(int personID)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeletePerson", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);

                    await connection.OpenAsync();

                    try
                    {
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

        }

        public async Task<string?> GetImageNameByIdAsync(int personID)
        {
            string? ImageName = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetPersonImageNameById", connection))
                {
                    
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", personID);

                    await connection.OpenAsync();

                    var result = await command.ExecuteScalarAsync();

                    if (result != null && result != DBNull.Value)
                        ImageName = result.ToString();
                }
            }

            return ImageName; 
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var exists = await _context.People.AsNoTracking().AnyAsync(p => p.Email == email);
            return exists;
        }


    }
}
