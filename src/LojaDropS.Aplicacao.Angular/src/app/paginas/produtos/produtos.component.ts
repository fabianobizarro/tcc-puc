import { Component, OnInit, ViewChild } from '@angular/core';
import { ProdutosService } from 'src/app/services/produtos.service';
import { CategoriasService } from 'src/app/services/categorias.service';
// declare var $: any;

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  pesquisa: string;
  listaProdutos: any[] = [];
  categorias: any[] = [];
  show: boolean = false;
  loading: boolean = false;
  page: number = 1;
  showAccordion: boolean = false;

  constructor(
    private service: ProdutosService,
    private categoriasServices: CategoriasService) { }

  ngOnInit() {
    this.obterCategorias();
  }

  toggleShowAccordion() {
    this.showAccordion = !this.showAccordion;
  }

  obterCategorias() {
    this.categoriasServices.obterCategorias()
      .subscribe(res => {
        this.categorias = res;
      }, err => {
        console.error(err)
      });
  }

  pesquisar() {
    this.listaProdutos = [];
    this.loading = true;
    this.page = 1;
    this.service.pesquisarProdutos(this.pesquisa, this.page)
      .subscribe(res => {
        this.show = true;
        this.listaProdutos = res;
      }, err => {
        console.error(err)
      })
      .add(() => this.loading = false);
  }

  carregarMais() {
    this.page++;
    this.service.pesquisarProdutos(this.pesquisa, this.page)
      .subscribe(res => {
        this.show = true;
        this.listaProdutos = [
          ...this.listaProdutos,
          ...res
        ];
      }, err => {
        console.error(err)
      });
  }

}
