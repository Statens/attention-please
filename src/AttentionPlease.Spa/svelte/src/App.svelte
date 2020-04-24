<script>

  import { onMount } from 'svelte';
  import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

  let connection = new HubConnectionBuilder()
  .withUrl("https://localhost:6001/signalr")
  .build();

  connection
  .start()
  .then(() => console.log('Connection started!'))
  .catch(err => console.log('Error while establishing connection :('));
  connection.on('BroadcastMessage', (data) => {
    console.log(data)
  });

  export let name;
  export let game;

  onMount(async () => {
  const res = await fetch(`https://localhost:6001/api/celebrations`);
  const dasd = await res.json();
  console.log(dasd[0]);
  name = dasd[0].title;
  });

</script>

<main>
	<h1>Hi, {name}!</h1>
	<h2>Lets play {game}!</h2>
	<p>Visit the <a href="https://svelte.dev/tutorial">Svelte tutorial</a> to learn how to build Svelte apps.</p>
</main>

<style>
	main {
		text-align: center;
		padding: 1em; 
		max-width: 250px;
		margin: 0 auto;
	}

	h1 {
		color: #369;
		text-transform: uppercase;
		font-size: 4em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>