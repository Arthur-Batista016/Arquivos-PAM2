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
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=120, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=140, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=130, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome")]
        public IActionResult GetByNome(string nome){
            var personagem_existe = personagens.FirstOrDefault(n => n.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if(personagem_existe == null){
                 return NotFound("PERSONAGEM NÂO ENCONTRADO");
            }else{
                 return Ok(personagem_existe);
            }
           
             
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago(){
            var eh_cavaleiro = personagens.RemoveAll(n => n.Classe == ClasseEnum.Cavaleiro);
            var personagens_pontos_vida = personagens.OrderByDescending(n=> n.PontosVida);
            if (eh_cavaleiro == 0){
               return NotFound("NAO TEM CAVALEIROS");
           }else{
                return Ok(personagens_pontos_vida);
                
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


        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem){
        
            if(novoPersonagem.Defesa<10 || novoPersonagem.Inteligencia>30){
                return BadRequest("Não e possivel adicionar personagens com menos de 10 de defesa ou mais que 30 de inteligencia");
            }else{
                return Ok(novoPersonagem);
                
            }
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem p){
            if(p.Classe == ClasseEnum.Mago && p.Inteligencia<35){
                return BadRequest("Não é possivel adicionar um Mago com menos de 35 de inteligencia");
            }else{
                return Ok(p);
            }
        }

        [HttpGet("GetByClasse")]
        public IActionResult GetByClasse(int id_classe){
            return Ok(personagens);
        }



    


    }
}