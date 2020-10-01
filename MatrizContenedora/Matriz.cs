using System;

namespace MatrizContenedora
{
    class Matriz
    {
        //Atributos
        private int tam;
        private int[,] matriz;

      

        //Constructores
        /// <summary>
        /// Usaremos a este constructor para rellenar la matriz de 10x10
        /// Que seran numeros enteros positivos, cuyo índice [0][0] será '1'
        /// Será nuestro constructor por defecto
        /// </summary>
        Matriz()
        {
            this.tam = 10;
            //Le damos un tamaño a la matriz
            this.matriz = new int[this.tam , this.tam];
            //Recorremos y rellenamos la matriz con numeros enteros positivos
            //Para ello también nos creamos un contador
            int cont = 1;
            for(int i=0; i < this.tam; i++){
                for(int j=0; j < this.tam; j++){
                    this.matriz[i,j] = cont++;
                }
            }
        }

        /// <summary>
        /// Este constructor nos permitirá crear un objeto/instancia de una matriz de 3x3
        /// Esta matriz ya estará creada con anterioridad en el MAIN
        /// (Cómo no pueden haber 2 constructores por defecto he tenido que pasarle la matriz)
        /// </summary>
        /// <param int[,]="martiz_a">Matriz que le pasaremos por parámetro</param>
        Matriz(int[,] martiz_a)
        {
            this.matriz = martiz_a;
        }

        /// <summary>
        /// Método que nos devolverá la matriz de enteros del objeto Matriz
        /// </summary>
        /// <returns>atributo/elemento this.matriz</returns>
        public int[,] getMatriz() { return this.matriz; }


        /// <summary>
        /// Metodo que nos imprimira las instancias de la clase Matriz
        /// </summary>
        public void mostrarMatriz()
        {
            Console.WriteLine("_____________________");
            for (int i = 0; i < this.matriz.GetLength(0); i++){
                Console.Write("[");
                for (int j = 0; j < this.matriz.GetLength(1); j++){
                    Console.Write(this.matriz[i, j] + " ");
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("_____________________");
        }


        /// <summary>
        /// Metodo estático que nos rellenara una matriz
        /// </summary>
        /// <param name="matriz_3x3">tipo matriz de numeros enteros</param>
        public static void rellenaMatriz(int[,] matriz_3x3)
        {
            for (int i = 0; i < matriz_3x3.GetLength(0); i++){
                for (int j = 0; j < matriz_3x3.GetLength(1); j++){
                    Console.Write("Posicion[" + i + "," + j + "] = ");
                    matriz_3x3[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        /// <summary>
        /// Usaremos un método para buscar una submatriz de 3x3(mat3) en la de 10x10(mat10)
        /// </summary>
        /// <param name="mat3">matriz de la instancia/objeto mat3</param>
        /// <param name="mat10">matriz de la instancia/objeto mat10</param>
        public static void compararMatrices(Matriz mat3, Matriz mat10) {
            //Atributos
            bool existeSubMatriz = false;
            int contador = 0;
            //Usaremos estas variables para obtener las posiciones de las matrices
            //Y así más adelante mostrar las coordenadas de las que coinciden
            int posicionInicial1 = -1, posicionInicial2 = -1, posicionFinal1 = -1, posicionFinal2 = -1; 
    
            //Cogeremos como índice la posición[0,0] de mat3
            //Con este índice de referencia buscaremos si hay alguna posición que coincida en mat10
            for(int i=0; i < mat10.getMatriz().GetLength(0); i++){
                for(int j=0; j < mat10.getMatriz().GetLength(1); j++){
                    //Comprobamos si coincide alguna coordenada
                    if(mat3.getMatriz()[0,0] == mat10.getMatriz()[i,j]){
                        //Cuando coinciden empezamos a recorrer ambas con las dimensiones de mat3
                        int m = i;
                        for(int k=0; k < mat3.getMatriz().GetLength(0); k++, m++){
                            //La variable 'n' obtendrá el valor de la variable 'j'
                            //Esto hará que cada vez que vuelva a ejecutarse el bucle tenga el índice correcto
                            int n = j;
                            for(int l=0; l < mat3.getMatriz().GetLength(1); l++, n++){
                                //Comparación para que no sobrepase las dimensiones de la matriz de 10x10
                                if (m < mat10.getMatriz().GetLength(0) && n < mat10.getMatriz().GetLength(1)){
                                    //Comprobamos que coinciden
                                    if (mat3.getMatriz()[k, l] == mat10.getMatriz()[m, n]){
                                        //Condición para obtener los índices de las posiciones iniciales
                                        if (contador == 0){
                                            posicionInicial1 = m;
                                            posicionInicial2 = n;
                                            //Condición para obtener los índices de las posiciones finales
                                        }else if (contador == 8){
                                            posicionFinal1 = m;
                                            posicionFinal2 = n;
                                        }
                                        contador++;
                                    }
                                    else{ existeSubMatriz = false; } 
                                }else {
                                //En el caso de encontrar un índice que se desborda, le damos a la  variable 'l' el valor de la longitud de la columna
                                //Así se sale del bucle 'for'
                                    l = mat3.getMatriz().GetLength(1);
                                }
                            }

                        }
                    }
                }
            }
            //La variable existeSubMatriz sólo sera 'true' si se han encontrado 9 posiciones que coincidan en esa misma submatriz
            if(contador == 9){ existeSubMatriz = true; }

            //Condicion de si existe
            if (existeSubMatriz){
                Console.WriteLine("Existe esa Submatriz dentro de la matriz de 10x10");
                Console.WriteLine("Las posiciones son:");
                Console.WriteLine("Posicion inicial = [" + posicionInicial1 + "," + posicionInicial2 + "]");
                Console.WriteLine("Posicion final = " + posicionFinal1 + "," + posicionFinal2 + "]");

            }else { Console.WriteLine("No se ha encontrado ninguna Submatriz dentro de la Matriz"); }
        }



        static void Main(string[] args)
        {
            //Atributo
            int[,] matriz3 = new int[3, 3];
            //A continuación vamos a rellenar la matriz de 3x3 llamando a un método
            Console.WriteLine("Inserte los valores de una matriz de 3x3");
            Console.WriteLine("Le recomiendo que los números sean enteros positivos");
            Matriz.rellenaMatriz(matriz3);

            //Creamos las instancias
            Matriz mat10 = new Matriz();        //Matriz 10x10
            Matriz mat3 = new Matriz(matriz3);  //Matriz 3x3

            //Las imprimimos por pantalla
            Console.WriteLine("Matriz Principal (10x10)");
            mat10.mostrarMatriz();
            Console.WriteLine("Submatriz/Matriz secundaria (3x3)");
            mat3.mostrarMatriz();

            //Llamamos al método que nos comprobará ambas matrices
            Matriz.compararMatrices(mat3, mat10);

        }
    }
}
