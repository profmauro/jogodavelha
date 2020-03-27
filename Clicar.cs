using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicar : MonoBehaviour
{
	public GameObject moveMouse, player1, player2;
	int cont = 0;
  int casa = 0;
	bool clicou;
  char letra;
  Player jogador1, jogador2;
  bool ganhou = false;
  GameController controle;
	
  void Start(){
    char l1, l2;
    jogador1 = player1.GetComponent<Player>();
    jogador2 = player2.GetComponent<Player>();
    jogador1.passaVez();
    controle = GameController.Instance;
    bool escolhaletra = Random.Range(0, 100) <= 50;
    if(escolhaletra){
      l1 = 'O';
    }else{
      l1 = 'X';
    }
    if(l1 == 'O'){
      l2 = 'X';
    }else{
      l2 = 'O';
    }
    jogador1.alterarLetra(l1);
    jogador2.alterarLetra(l2);
  }
  void Update(){
	  Cursor.visible = false;
    moveMouse.GetComponent<Movendo_mouse>().MovendoLapis();
	  if(clicou){
      cont = cont + 1;
	  	if(cont <= 47){
		    moveMouse.GetComponent<Movendo_mouse>().semMouse();
	  	}else{
        moveMouse.GetComponent<Movendo_mouse>().comMouse();
        clicou = false;
        if(ganhou){
          SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }else{
          if(controle.isBoot() && !jogador1.deQuemVez()){
            casa = jogador2.jogar(jogador1.Casas(),jogador2.Casas());
            letra = jogador2.qualLetra();
            jogador2.addCasa(casa);
            if(jogador2.verificavitoria()){
              controle.ganhou(false);
              controle.perdeu(true);
              ganhou = true;
            }
            jogador1.passaVez();
            GameObject.Find("escrevendo"+casa.ToString()).GetComponent<Animator>().SetBool("casa"+casa.ToString(), true);
            GameObject.Find("escrevendo"+casa.ToString()).GetComponent<Animator>().SetBool("escreve"+letra.ToString(),true);
            clicou = true;
          }
        }
      }
	  }else{
		  cont = 0;
	  }
  }

  void OnMouseDown() {
    casa = GetComponent<Animator>().GetInteger("num_casa");
    if(jogador1.deQuemVez() && !(GetComponent<Animator>().GetBool("casa"+casa.ToString()))){
      clicou = true;
      letra = jogador1.qualLetra();
      jogador1.addCasa(casa);
      if(jogador1.verificavitoria()){
        controle.ganhou(true);
        controle.perdeu(false);
        ganhou = true;
      }else{
        if(jogador1.ficouVelha()){
          controle.empatou(true);
          controle.empatou(false);
          ganhou = true;
          jogador1.passaVez();
        }
      }
      GetComponent<Animator>().SetBool("casa"+casa.ToString(), true);
      GetComponent<Animator>().SetBool("escreve"+letra.ToString(),true);
      jogador1.passaVez();
    }
  }

}
