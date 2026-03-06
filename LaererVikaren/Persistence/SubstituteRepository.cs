using LaererVikaren.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace LaererVikaren.Persistence
{
    public class SubstituteRepository : BaseRepo<Substitute>
    {
        public SubstituteRepository() : base()
        {
        }

        public override void Add(Substitute substitute)
        {
        }

        public List<Substitute> GetMatchingSubstitutes(DateTime? date, int timespan, string subject)
        {
            List<Substitute> substitutes = new();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("spGetMatchingSubstitute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = date;
                    cmd.Parameters.Add("@Timespan", SqlDbType.Int).Value = timespan;
                    cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 50).Value = subject;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Substitute sub = new Substitute()
                            {
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                PhoneNumber = (int)dr["PhoneNumber"],
                            };
                            substitutes.Add(sub);
                        }
                    }
                    return substitutes;
                }
            }
        }
    }
}
