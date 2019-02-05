using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class PacienteDal : Conexao
    {

        public void salvar(Paciente paciente)
        {

            try{

                command = new MySqlCommand();

                var sql = "insert into paciente(idCidade, nome, dtCadastro)" +
                    "values(@idCidade, @nome, current_timestamp())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idCidade", paciente.IdCidade);
                command.Parameters.AddWithValue("@nome", paciente.Nome);
                command.ExecuteNonQuery();

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public List<Paciente> Listar()
        {

            try
            {

                command = new MySqlCommand();

                var sql = "select * from paciente";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Paciente> listaPaciente = new List<Paciente>();

                while (dataReader.Read()){

                    Paciente paciente = new Paciente();
                    paciente.Id = Convert.ToInt32(dataReader["id"]);
                    paciente.Nome = dataReader["nome"].ToString();
                    paciente.DtCadastro = dataReader["crm"].ToString();
                }

                return listaPaciente;

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }


        public PacienteDal()
        {
        }
    }
}
