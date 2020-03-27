using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    List<int> casas = new List<int>();
    string nome;
    char jogaCom;
    bool minhaVez;
    public Text texto1, texto2;
    void Start(){
      texto1.text = "Você.\nVitória: "+GameController.Instance.getVitoria(true).ToString()+"\nEmpate: "+GameController.Instance.getEmpate(true).ToString();
      texto2.text = "Boot:\nVitória: "+GameController.Instance.getVitoria(false).ToString()+"\nEmpate: "+GameController.Instance.getEmpate(false).ToString();

    }
    public void addCasa(int casa){
      casas.Add(casa);
    }

    public List<int> Casas(){
      return casas;
    }

    public bool verificavitoria(){
      bool linha1 = casas.Contains(1) && casas.Contains(2) && casas.Contains(3);
      bool linha2 = casas.Contains(5) && casas.Contains(9) && casas.Contains(15);
      bool linha3 = casas.Contains(20) && casas.Contains(25) && casas.Contains(36);
      bool coluna1 = casas.Contains(1) && casas.Contains(5) && casas.Contains(20);
      bool coluna2 = casas.Contains(2) && casas.Contains(9) && casas.Contains(25);
      bool coluna3 = casas.Contains(3) && casas.Contains(15) && casas.Contains(36);
      bool principal = casas.Contains(1) && casas.Contains(9) && casas.Contains(36);
      bool secundaria = casas.Contains(3) && casas.Contains(9) && casas.Contains(20);

      if(linha1 || linha2 || linha3 || coluna1 || coluna2 || coluna3 || principal || secundaria){
        return true;
      }else{
        return false;
      }
    }

    public void passaVez(){
      if(minhaVez){
        minhaVez = false;
      }else{
        minhaVez = true;
      }
    }

    public bool deQuemVez(){
      return minhaVez;
    }

    public void alterarLetra(char letra){
      jogaCom = letra;
    }

    public char qualLetra(){
      return jogaCom;
    }

    public bool ficouVelha(){
      if(casas.Count == 5){
        return true;
      }else{
        return false;
      }
    }
    
    public int jogar(List<int> letrashumano, List<int> letrasboot){
      List<int> l = new List<int>();
      letrashumano.ForEach(item => l.Add(item));
      letrasboot.ForEach(item => l.Add(item));
      List<int> todasCasas = new List<int>{1, 2, 3, 5, 9, 15, 20, 25, 36};
      foreach(int item in l){
        todasCasas.Remove(item);
      }
      int quant = l.Count;
      switch (quant){
        case 3:
          int soma = letrashumano.Sum();
          if(soma == 5 || soma == 25 || soma == 45){
            return 1;
          }
          if (soma == 4 || soma == 34)
          {
            return 2;
          }
          if (soma == 3 || soma == 29 || soma == 51)
          {
            return 3;
          }
          if (soma == 21 || soma == 24)
          {
            return 5;
          }
          if(soma == 37 || soma == 23 || soma == 27 || soma == 20){
            return 9;
          }
          if (soma == 14 || soma == 39)
          {
            return 15;
          }
          if (soma == 6 || soma == 12 || soma == 61)
          {
            return 20;
          }
          if (soma == 11 || soma == 56)
          {
            return 25;
          }
          if (soma == 45 || soma == 18 || soma == 10)
          {
            return 36;
          }
          break;
        default:
          if(!letrashumano.Contains(9) && !letrasboot.Contains(9)){
            return 9;
          }else{
            int i = Random.Range(0, todasCasas.Count - 1);
            return todasCasas[i];
          }
      }
      return 2;
    }
}
