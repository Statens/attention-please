<script>
  import { onMount } from "svelte";
  import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";

  let connection = new HubConnectionBuilder()
    .withUrl("https://localhost:6001/signalr")
    .build();

  connection
    .start()
    .then(() => console.log("Connection started!"))
    .catch(err => console.log("Error while establishing connection :("));
  connection.on("BroadcastMessage", data => {
    game = data.message;
    localGame.push(data.message);
    console.log(localGame);
  });
  let localGame = [];
  export let name;
  export let game;

  let celebrations = [];

  onMount(async () => {
    const res = await fetch(`https://localhost:6001/api/celebrations`);
    const dasd = await res.json();
    console.log(dasd[0]);
    celebrations = dasd;
    name = dasd[0].title;
  });
</script>

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

<main>
  <h1>allå, allå!</h1>
  <h2>I got {game} {name}!</h2>
  <div>

    <ul>
      {#each celebrations as celebration}
        <li>
            {celebration.title}
        </li>
      {/each}
    </ul>
  </div>

  <p style="display:none;">
    Visit the
    <a href="https://svelte.dev/tutorial">Svelte tutorial</a>
    to learn how to build Svelte apps.
  </p>
</main>
