using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int vitoria1 = 0;
    int vitoria2 = 0;
    int empate1 = 0;
    int empate2 = 0;
    int derrota1 = 0;
    int derrota2 = 0;
    int pontos1 = 0;
    int pontos2 = 0;
    bool boot = true;
    string nome;
    public static GameController Instance{get; set;}
    private void Awake(){
        if(Instance == null){
          Instance = this;
          DontDestroyOnLoad(gameObject);
        }else{
          Destroy(gameObject);
        }
    }
    public void ganhou(bool isPlayer1){
      if(isPlayer1){
        vitoria1 += 1;
      }else{
        vitoria2 += 1;
      }
    }

    public void empatou(bool isPlayer1){
      if(isPlayer1){
        empate1 += 1;
      }else{
        empate2 += 1;
      }
    }

    public void perdeu(bool isPlayer1){
      if(isPlayer1){
        derrota1 += 1;
      }else{
        derrota2 += 1;
      }
    }

    public void pontuou(bool isPlayer1){
      if(isPlayer1){
        pontos1 += 1;
      }else{
        pontos2 += 1;
      }
    }

    public void meuNome(string nome){
      this.nome = nome;
    }

    public int getVitoria(bool isPlayer1){
      if(isPlayer1){
        return vitoria1;
      }else{
        return vitoria2;
      }
    }

    public int getEmpate(bool isPlayer1){
      if(isPlayer1){
        return empate1;
      }else{
        return empate2;
      }
    }

    public int getDerrota(bool isPlayer1){
      if(isPlayer1){
        return derrota1;
      }else{
        return derrota2;
      }
    }

    public int getPontos(bool isPlayer1){
      if(isPlayer1){
        return pontos1;
      }else{
        return pontos2;
      }
    }

    public string getNome(){
      return nome;
    }

    public bool isBoot(){
      return boot;
    }

}
