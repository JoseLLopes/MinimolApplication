# MinimolApplication
---
## __Sistemas do jogo__

### __Sistema de dano__ 
Foi modificado o antigo sistema de detecção de colisão, onde o projétil verificava com um trigger se o objeto que foi colidido estava marcado com a Tag “Enemy”;

#### __Problemas detectados:__
- Adicionar um novo If sempre que tiver um objeto novo que o projétil pode colidir;

- “OnTriggerEnter” utiliza a física e, às vezes, acaba não detectando a colisão quando o objeto está se locomovendo rapidamente.

#### __Solução:__

- Foi criada a Interface “IDamageable” não dependendo de tags, flexibilizando a utilização e permitindo que qualquer objeto que implementa a interface “IDamageable” seja atingido. Tornando também que seja desnecessária a mudança na classe “Bullet” para adicionar novos objetos atingíveis e cada objeto é responsável pelos eventos que acontecem ao ser atingido na função “TakeDamage”;

- Foi modificada a maneira de detecção de colisão para Raycast e a função “Update” foi atualizada para “FixedUpdate” para se ter uma melhor precisão principalmente quando os objetos estão movendo rapidamente.

---

### __Instanciando os projéteis__
Foi modificada a maneira como os projéteis são instanciados
	
#### __Problemas detectados:__
- Instanciar várias vezes o mesmo objeto consome memória desnecessária, instanciar e destruir são operações que custam desempenho, quando um objeto é destruído geralmente são coletados pelo coletor de lixo (garbage collector) do sistema, que é responsável por liberar memória de objetos que não são mais referenciados. Gerar esse lixo com frequência faz com que o coletor trabalhe mais para liberar espaço.

#### __Solução:__
- Criação de um sistema de “pooling“ para fazer a reutilização de projéteis já instanciados, desabilitando-os na cena após o uso e ficando em espera para poder ser reutilizado quando precisar.

---

### __Desempenho__

#### __Problemas detectados:__
- O desempenho do jogo, quando enche de inimigos, cai devido a função “Update” estar sempre procurando o player e checando a física com a função “OnCollisionEnter”.
- Sombras em alto nível de qualidade.

#### __Solução:__
- Foi removida a função “OnCollisionEnter”, essa verificação estava sendo feita a cada frame o que causava sobrecarga no desempenho do jogo;
- Removida a procura pelo player a cada frame na função “Update”, melhorando o desempenho do jogo;
Ativado o GPU Instancing no material, isso faz com que a GPU instancie objetos em massa em vez de renderizar individualmente.
- Removido o “Rigdibody” do player e do inimigo.
- Reduzido o nível de qualidade das sombras para “Hard Shadow”.

---

### __Vida do inimigo__
- Criado o script “CharacterHealth” específico para personagens com vida que implementa a interface “IDamageable”. Então quando o projétil encontrar o inimigo, com essa interface implementada, vai chamar o método “TakeDamage” e executar os eventos específicos da classe “CharacterHealth”.

---

### __Vida do player__
- Criado o script “PlayerHealth” herdando da classe “CharacterHealth”, sobrescrevendo o método “TakeDamage” e adicionando variáveis para controlar o espaço de tempo que o player não pode ser atingido.

---

### __Input de atirar__
- Melhorada a jogabilidade, agora o player não precisa mais ficar clicando para atirar, basta segurar o botão esquerdo do mouse;
A taxa de disparo é armazenada em uma variável, flexibilizando a criação de outros tipos de armas.

---

### __Ataque do inimigo__
- Criado o script “EnemyAttack” que checa se o inimigo está próximo ao player, caso esteja é lançado um raycast curto para detectar e causar dano ao Player.
- Foi removido o sistema de colisão por física para reduzir o consumo com cálculos de física quando se tem muitos inimigos.
- Foi removido o sistema de colisão por física para reduzir o consumo com cálculos de física quando se tem muitos inimigos.

---

### __Spawn de inimigos__
- Criado o script “Spawner” para Instanciar as criaturas em uma área determinada no inspector, foi adicionado um “Gizmo” para ter noção visual da área de spawn;
- Criado o Scriptable Object “SO_WavesSettings” e o struct “Wave” para conter informações do tempo entre o spawn de creaturas, os tipos de criaturas e a quantidade para cada wave;
- Criado o script “WaveController” Para controlar em qual wave o jogador se encontra, quantas criaturas ainda estão vivas. Ele também controla o tempo de spawn para cada criatura, chama o spawner para instanciar e vai para próxima wave se os inimigos estiverem mortos;
- Para auxiliar e remover a necessidade de conferir se todos os inimigos estão mortos, foi criado o script “WaveEnemy” que herda de “CharacterHealth” e sobrepõe o método “Death” fazendo uma chamada para “WaveController” remover o inimigo da lista de inimigos vivos.

---

### __Player Canvas UI__
- Foi criado o script “PlayerUI” para controlar a barra de vida do jogador.
- Foi criada a classe “HealthData” responsável por armazenar a vida e a vida máxima e repassar para o “PlayerUI” através do UnityEvent onTakeDamage, adicionado no script ”PlayerHeatlh”

---

## __Game Juice__ 

### __Sons__
- Criado o script “EnemiesSoundController” para controlar os sons dos inimigos, os inimigos quando são atingidos chamam o função neste script. Foi feito isso para que todos os inimigos usem apenas um “Audio Source” evitando o consumo de recursos desnecessários.

### __Partículas__
- Adicionadas partículas nos inimigos quando são atingidos para melhorar o feedback do jogo para o usuário

