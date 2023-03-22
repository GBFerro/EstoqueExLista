using System.Collections.Generic;
using System.Xml.Linq;
using EstoqueExLista;

List<Produto> estoque = new List<Produto>();

do
{
    int op = Menu();
    switch (op)
    {
        case 1:
            Produto produto = CreateProduct();
            if (VerifyDups(produto))
            {
                Console.WriteLine("Já existe este item");
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadKey();
            }
            else
            {
            estoque.Add(produto);
            }
            estoque = estoque.OrderBy(Produto => Produto.ID).ToList();
            Console.Clear();
            break;

        case 2:
            EditQuantity(FindProduct());
            Console.Clear();
            break;

        case 3:
            estoque.Remove(FindProduct());
            break;

        case 4:
            PrintList(estoque);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 5:
            estoque = OrderByQuantity(estoque);
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            break;

        case 6:
            System.Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opção inválida");
            Console.Clear();

            break;
    }

} while (true);

void EditQuantity(Produto produto)
{

    foreach (var item in estoque)
    {
        if (item.ID == produto.ID)
        {
            Console.WriteLine("Digite a quantidade atual do item");
            item.Quantity = int.Parse(Console.ReadLine());
        }
    }
}

List<Produto> OrderByQuantity(List<Produto> estoque)
{
    Console.Clear();
    return estoque.OrderBy(x=>x.Quantity).ToList();
}

bool VerifyDups(Produto produto)
{
    foreach (var item in estoque)
    {
        if (item.ID == produto.ID)
        {
            return true;
        }
    }
    return false;
}

Produto CreateProduct()
{
    Console.Clear();
    Console.Write("Informe o ID do item: \n");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição: \n");
    string name = Console.ReadLine();
    Console.Write("Informe a quantidade: \n");
    int quantity = int.Parse(Console.ReadLine());

    Produto produto = new Produto(id, name, quantity);

    return produto;
}

Produto FindProduct()
{
    Console.WriteLine("Informe o Id do produtp: ");
    var id = int.Parse(Console.ReadLine());

    foreach (var item in estoque)
    {
        if (item.ID.Equals(id))
        {
            return item;
        }
    }
    return null;
}

int Menu()
{
    Console.Clear();
    Console.WriteLine(">>>Menu de opções<<<\n\n1 - Insere Produto\n2 - Editar Produto\n" +
        "3 - Remover Produto\n4 - Mostrar Estoque\n5 - Ordenar Produto por quantidade\n6 - Sair\n\n" +
        "Escolha uma opção: ");

    var aux = int.Parse(Console.ReadLine());

    return aux;

}

void PrintList(List<Produto> list)
{
    Console.Clear();
    for (int i = 0; i < estoque.Count; i++)
    {
        Console.WriteLine(estoque[i].ToString());
    }

}
