using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enums;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
         private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome")]
        public IActionResult GetByNome(string nome){
            var personagem_existe = personagens.FirstOrDefault(n => n.Nome.Equals(nome));
            if(personagem_existe == null){
                 return NotFound("PERSONAGEM NÂO ENCONTRADO");
            }else{
                 return Ok(personagem_existe);
            }
           
             
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago(){
            var eh_cavaleiro = personagens.RemoveAll(n => n.Classe == ClasseEnum.Cavaleiro);
            if (eh_cavaleiro == 0){
               return Ok("NAO TEM CAVALEIROS");
           }else{
                return Ok(personagens);
                
            }
            }
        
        
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas(){
            //quantidade de personagens
            int quantidade_pers = personagens.Count();
            //soma das inteligencias
            int somaInteligencia = personagens.Sum(pers => pers.Inteligencia);
            //exibicao
            return Ok($"quantidade de personagens:  {quantidade_pers},   Soma Inteligencia: {somaInteligencia}"); 


        }


        //[HttpPost("PostValidacao")]
        //public IActionResult PostValidacao(){
            //var inteligencia = personagens.FirstOrDefault(p => p.Inteligencia = Inteligencia)
            //var defesa = personagens.FirstOrDefault()
            //if(defesa<10 && inteligencia>30){

            //}else{
            //    return
          //  }
        //}




    


    }
}