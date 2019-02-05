using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class MedicoDal : Conexao
    {

        public void salvar(Medico medico)
        {

            try{

                command = new MySqlCommand();

                var sql = "insert into medico(idEspecialidade, nome, crm, dtCadastro)" +
                    "values(@idEspecialidade, @nome, @crm, current_timestamp())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEspecialidade", medico.IdEspecialidade);
                command.Parameters.AddWithValue("@nome", medico.Nome);
                command.Parameters.AddWithValue("@crm", medico.Crm);
                command.ExecuteNonQuery();
                
            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public List<Medico> Listar(){

            try{

                command = new MySqlCommand();

                var sql = "select * from medico";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Medico> listaMedico = new List<Medico>();

                while (dataReader.Read()){

                    Medico medico = new Medico();
                    medico.Id = Convert.ToInt32(dataReader["id"]);
                    medico.Nome = dataReader["nome"].ToString();
                    medico.DtCadastro = dataReader["crm"].ToString();
                }

                return listaMedico;

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public MedicoDal()
        {
        }
    }
}
