import { ItemVenda } from "./item-venda";

export interface Venda {
    cliente: string,
    itens?: ItemVenda[],
    formaPagamentoId: number
}