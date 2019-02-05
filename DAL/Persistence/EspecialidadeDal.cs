using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class EspecialidadeDal : Conexao
    {

        public void salvar(Especialidade especialidade)
        {

            try{

                command = new MySqlCommand();

                var sql = "insert into especialidade(descricao, dtCadastro)" +
                    "values(@descricao, current_timestamp())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@descricao", especialidade.Descricao);
                command.ExecuteNonQuery();


            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public List<Especialidade> Listar()
        {

            try{


                command = new MySqlCommand();

                var sql = "select * from especialidade";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Especialidade> listaEspecialidade = new List<Especialidade>();

                while (dataReader.Read()){

                    Especialidade especialidade = new Especialidade();
                    especialidade.Id = Convert.ToInt32(dataReader["id"]);
                    especialidade.Descricao = dataReader["descricao"].ToString();
                    especialidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaEspecialidade.Add(especialidade);
                }

                return listaEspecialidade;

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public EspecialidadeDal()
        {
        }
    }
}
