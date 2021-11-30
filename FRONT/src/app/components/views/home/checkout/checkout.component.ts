import { Component, OnInit } from '@angular/core';
import { ItemVenda } from "src/app/models/item-venda";
import { Pagamento } from 'src/app/models/pagamento';
import { PagamentoService } from 'src/app/services/pagamento.service';
import { ItemService } from "src/app/services/item.service";
import { Venda } from 'src/app/models/venda';
import { VendaService } from 'src/app/services/venda.service';
import { Router } from "@angular/router";

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

    itens: ItemVenda[] = [];
    colunasExibidas: String[] = ["nome", "preco", "quantidade", "total"];
    valorTotal!: number;
    selectedValue: any = ''

    venda: Venda = {
        cliente: '',
        itens: [],
        formaPagamentoId: 1
    }

    pagamentos: Pagamento[] = []

    constructor(
        private itemService: ItemService,
        private pagamentoService: PagamentoService,
        private vendaService: VendaService,
        private router: Router,
    ) {}

    ngOnInit(): void {
        let carrinhoId = localStorage.getItem("carrinhoId")! || "";
        this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
            this.itens = itens;
            this.venda.itens = itens
            console.log(this.venda)
            this.valorTotal = this.itens.reduce((total, item) => {
                return total + item.preco * item.quantidade;
            }, 0);
        });

        this.pagamentoService.get().subscribe((itens) => {
            this.pagamentos = itens;

            console.log(itens)
        })
    }

    concluirCompra(): void {
        this.vendaService.create(this.venda).subscribe((resp) => {
            console.log(resp)
            this.router.navigate([""]);
        })
    }

}
