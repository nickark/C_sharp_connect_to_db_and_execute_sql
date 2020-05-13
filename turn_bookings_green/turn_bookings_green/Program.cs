using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.ObjectModel;

namespace turn_bookings_green
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read the Configuration file
            string[] lines = System.IO.File.ReadAllLines(@"turn_bookings_green.config");
            string connection_string = "";
            string firmcode = lines[0].Substring(0, 2);
            int connection_string_starting_point = lines[0].IndexOf("<");
            int connection_string_end_point = lines[0].IndexOf(">");
            object sql_returnValue = null;


            int connection_string_length = connection_string_end_point - (connection_string_starting_point + 1);

            connection_string = lines[0].Substring(connection_string_starting_point + 3, connection_string_length - 3);

            SqlConnection myConnection = new SqlConnection(connection_string);

            myConnection.Open();

            string code = @"delete  FROM [My_EG_Reservation_2011].[dbo].[Res_Error]  where ResRefID in  (" +
  "   SELECT  RefID" + 
  "  FROM [My_XXXXXXXXXX].[dbo].[XXXXXXXXX]" +
  "  where HotelID in" + 
  "  (" +
  "  select HotelID from [My_XXXXXXXXX].[dbo].[XXXXXXXXXXX] where HotelName" + 
  "  in" + 
  "  (" +
  "  'ANREISEPAKET INLAND'    ," +
  "  'TAGESAUSFLUG LUXOR'   ," +
  "  'LUXOR - HURGHADA OW' ," +
  "  'LUXOR À LA CARTE' ," +
  "  'HURGHADA -'," +
  "  '1 TAG KAIRO AB HRG' ," +
  "  'KAIRO À LA CARTE'  , " +
  "  'HURGHAD'," +
  "  'KAIRO - HURGHADA OW' ," +
  "  '2 TAGE KAIRO' " +
   "  )" +
  "  )" +
   "  )  ";



            SqlCommand myCommand = new SqlCommand(code, myConnection);

            myCommand.CommandTimeout = 21600;

            sql_returnValue = myCommand.ExecuteScalar();

            myConnection.Close();


            

        }
    }
}
