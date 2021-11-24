import { Component, OnInit } from '@angular/core';
import { Exercicios } from '../exercicios';

@Component({
  selector: 'app-treino',
  templateUrl: './treino.component.html',
  styleUrls: ['./treino.component.css']
})
export class TreinoComponent implements OnInit {

  constructor() { }

  exercicios = Exercicios;

  ngOnInit(): void {
  }

}
