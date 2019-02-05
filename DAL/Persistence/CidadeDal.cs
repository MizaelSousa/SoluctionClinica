using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class CidadeDal : Conexao
    {

        public void salvar(Cidade cidade)
        {

            try{

                command = new MySqlCommand();

                var sql = "insert into cidade(idEstado, descricao, dtCadastro)" +
                    "values(@idEstado, @descricao, current_timestamp())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@idEstado", cidade.IdEstado);
                command.Parameters.AddWithValue("@descricao", cidade.Descricao);
                command.ExecuteNonQuery();


            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public List<Cidade> Listar()
        {

            try{


                command = new MySqlCommand();

                var sql = "select * from cidade";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Cidade> listaCidade = new List<Cidade>();

                while (dataReader.Read()){

                    Cidade cidade = new Cidade();
                    cidade.Id = Convert.ToInt32(dataReader["id"]);
                    cidade.Descricao = dataReader["descricao"].ToString();
                    cidade.DtCadastro = dataReader["dtCadastro"].ToString();

                    listaCidade.Add(cidade);
                }

                return listaCidade;

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{



            }

        }

        public CidadeDal()
        {
        }
    }
}
