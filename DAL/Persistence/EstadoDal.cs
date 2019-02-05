using System;
using MySql.Data.MySqlClient;
using BLL.Model;
using System.Collections.Generic;

namespace DAL.Persistence
{
    public class EstadoDal : Conexao
    {

        public void salvar(Estado estado){

            try{
                
                var sql = "insert into estado(nome, sigla, dtCadastro)" +
                    "values(@nome, @sigla, current_timestamp())";

                command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@nome", estado.Nome);
                command.Parameters.AddWithValue("@sigla", estado.Sigla);
                command.ExecuteNonQuery();

            }catch(Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public List<Estado> Listar(){

            try{

                command = new MySqlCommand();

                var sql = "SELECT * FROM estado";

                command = new MySqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                List<Estado> listaEstado = new List<Estado>();

                while(dataReader.Read()){

                    Estado estado = new Estado();
                    estado.Id = Convert.ToInt32(dataReader["id"]);
                    estado.Nome = dataReader["nome"].ToString();
                    estado.Sigla = dataReader["sigla"].ToString();

                    listaEstado.Add(estado);
                }

                return listaEstado;

            }catch (Exception erro){

                throw new Exception("Erro ao registrar dado " + erro.Message + erro.ToString());

            }finally{

            }

        }

        public EstadoDal(){

        }

    }
}
