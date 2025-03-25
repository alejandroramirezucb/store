﻿using System;
using System.Reflection;

public class console
{
    private int option;
    private users listUsers;
    private inventory listInventory;

    public console()
    {
        this.listUsers = new users();
        this.listInventory = new inventory();
    }

    public void login()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------Bienvenido-----------------------------------\n");
            Console.WriteLine("1. Iniciar Sesion como Administrador " +
                              "| 2. Iniciar Sesion como Cliente " +
                              "| 3. Salir\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        adminMenu();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida");
                Console.ReadKey();
            }
        }
    }

    public void adminMenu()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------Menu-------------------------------------------------------\n");
            Console.WriteLine("1. Gestion de Inventario " +
                              "| 2. Ver Inventario " +
                              "| 3. Gestion de Usuarios " +
                              "| 4. Ver Usuarios " +
                              "| 5. Reportes " +
                              "| 6. Regresar\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        inventoryManagement();
                        break;
                    case 2:
                        viewInventory();
                        break;
                    case 3:
                        userManagement();
                        break;
                    case 4:
                        viewUsers();
                        break;
                    case 5:
                        Console.WriteLine("Funcionalidad de Reportes no implementada.");
                        Console.ReadKey();
                        break;
                    case 6:
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida");
                Console.ReadKey();
            }
        }
    }

    public void inventoryManagement()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------Gestion de Inventario----------------------------------\n");
            Console.WriteLine("1. Agregar Producto | 2. Eliminar Producto " +
                              "| 3. Aumentar Stock | 4. Reducir Stock | 5. Regresar\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Nombre del Producto : ");
                        string productName = Console.ReadLine();
                        Console.Write("Marca del Producto : ");
                        string productBrand = Console.ReadLine();
                        Console.Write("Codigo de Barras del Producto : ");
                        int productBarcode;
                        if (!int.TryParse(Console.ReadLine(), out productBarcode))
                        {
                            Console.WriteLine("Codigo de Barras inválido.");
                            Console.ReadKey();
                            break;
                        }
                        productType newProductType = new productType(productName, productBrand, productBarcode);
                        listInventory.addProductType(newProductType);
                        Console.WriteLine("Producto agregado con éxito.");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Funcionalidad de eliminación de producto no implementada.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Funcionalidad de aumento de stock no implementada.");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Funcionalidad de reducción de stock no implementada.");
                        Console.ReadKey();
                        break;
                    case 5:
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida");
                Console.ReadKey();
            }
        }
    }

    public void viewInventory()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------Ver Inventario-------------------------------------------\n");
            Console.WriteLine("1. Tabla de Productos | 2. Tabla de Categorias " +
                              "| 3. Tabla de productos de una Categoria " +
                              "| 4. Regresar\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Funcionalidad de Tabla de Productos no implementada.");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Funcionalidad de Tabla de Categorias no implementada.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Funcionalidad de productos por Categoria no implementada.");
                        Console.ReadKey();
                        break;
                    case 4:
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida");
                Console.ReadKey();
            }
        }
    }

    public void userManagement()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------Gestion de Usuarios--------------------------------\n");
            Console.WriteLine("1. Agregar Usuario | 2. Eliminar Usuario " +
                              "| 3. Cambiar Rango de Usuario " +
                              "| 4. Regresar\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string userName = Console.ReadLine();
                        Console.Write("ID: ");
                        int userID;
                        if (!int.TryParse(Console.ReadLine(), out userID))
                        {
                            Console.WriteLine("ERROR: ID invalido");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Contraseña: ");
                        string userPassword = Console.ReadLine();
                        Console.Write("¿El usuario es Admin? (s/n): ");
                        string userAdminScanner = Console.ReadLine();
                        bool userAdmin = (userAdminScanner.ToLower() == "s");
                        if (listUsers.addUser(userName, userID, userPassword, userAdmin) == true)
                        {
                            Console.WriteLine("EXITO: Usuario agregado");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Ingrese el ID del usuario a eliminar: ");
                        int userIDDel;
                        if (int.TryParse(Console.ReadLine(), out userIDDel))
                        {
                            if (listUsers.delUser(userIDDel))
                            {
                                Console.WriteLine("EXITO: Usuario eliminado");
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Usuario no encontrado");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Entrada invalida");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Ingrese el ID del usuario a modificar: ");
                        int userIDUpdate;
                        if (!int.TryParse(Console.ReadLine(), out userIDUpdate))
                        {
                            Console.WriteLine("ERROR: Entrada invalida");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Cambie el rango del usuario (true para Administrador, y false para Cliente): ");
                        bool newRange;
                        if (!bool.TryParse(Console.ReadLine(), out newRange))
                        {
                            Console.WriteLine("ERROR: Entrada invalida para el rango");
                            Console.ReadKey();
                            break;
                        }
                        user current = listUsers.getUserByID(userIDUpdate);
                        if (current != null)
                        {
                            current.setUserAdmin(newRange);
                            Console.WriteLine("EXITO: Rango actualizado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Usuario no encontrado");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida");
                Console.ReadKey();
            }
        }
    }

    public void viewUsers()
    {
        bool regresar = false;
        while (!regresar)
        {
            Console.Clear();
            Console.WriteLine("--------------------------Ver Usuarios-------------------------\n");
            Console.WriteLine("1. Tabla de Administradores | 2. Tabla de Clientes " +
                              "| 3. Regresar\n");
            Console.Write("Opcion: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        listUsers.printUserAdmin();
                        Console.ReadKey();
                        break;
                    case 2:
                        listUsers.printUserCustomer();
                        Console.ReadKey();
                        break;
                    case 3:
                        regresar = true;
                        break;
                    default:
                        Console.WriteLine("ERROR: Opcion no valida");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Entrada invalida.");
                Console.ReadKey();
            }
        }
    }
}
