using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dental.Core;
namespace Dental.DAL
{
    public static class DoctorDB
    {
        public static void insertDoctor(Doctor doctor)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string insertDoctorQuerry = String.Format(@"INSERT INTO doctor (name,address,number,notes)VALUES ('{0}','{1}','{2}','{3}');", doctor.name, doctor.address, doctor.number,doctor.notes);
                cmd.CommandText = insertDoctorQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
            //    //System.Windows.Forms.MessageBox.Show("Added");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }
        public static void updateDoctor(Doctor doctor)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string updatedoctorQuerry = String.Format(@"UPDATE  doctor SET name ='{0}',address = '{1}' ,number = '{2}' ,notes = '{4}'  WHERE id = {3}", doctor.name, doctor.address, doctor.number , doctor.id,doctor.notes);


                cmd.CommandText = updatedoctorQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Updated");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }
        public static void deleteDoctor(Doctor doctor)
        {

            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;

            try
            {
                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                string deletedoctortQuerry = String.Format(@"DELETE FROM doctor WHERE id = {0};", doctor.id);
                cmd.CommandText = deletedoctortQuerry;
                cmd.Connection = sql;
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("Deleted");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();
            }

        }
        public static List<Doctor> selectDoctors()
        {
            SQLiteConnection sql = new SQLiteConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader reader;
            //List*************
            List<Doctor> doctors = new List<Doctor>();

            try
            {


                sql.ConnectionString = ConnectionString.connectionString;
                sql.Open();
                //select query
                string selectDoctorsQuery = @"SELECT DOCTOR.ID as ID, DOCTOR.NAME as DOCTOR_NAME, Doctor.ADDRESS as DOCTOR_ADDRESS , Doctor.NUMBER as DOCTOR_NUMBER, Doctor.notes as DOCTOR_NOTES  FROM Doctor";
                cmd.CommandText = selectDoctorsQuery;
                cmd.Connection = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // create patient
                    Doctor doctor = new Doctor();

                    doctor.id = int.Parse(reader["ID"].ToString());
                    doctor.name = reader["Doctor_NAME"].ToString();
                    doctor.address= reader["DOCTOR_ADDRESS"].ToString();
                    doctor.number = reader["Doctor_NUMBER"].ToString();
                    doctor.notes = reader["Doctor_NOTES"].ToString();




                    doctors.Add(doctor);
                }
                reader.Close();
              //  //System.Windows.Forms.MessageBox.Show("Selected");

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            finally
            {
                sql.Close();

            }
            return doctors;

        }



    }

}

