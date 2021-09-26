<script>
  import jwtDecode from "jwt-decode";
  import { onMount } from "svelte";
  import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";

  let connection = new HubConnectionBuilder()
    .withUrl("https://localhost:6001/signalr")
    .build();

  connection
    .start()
    .then(() => console.log("Connection started!"))
    .catch((err) => console.log("Error while establishing connection :(", err));
  connection.on("BroadcastMessage", (data) => {
    game = data.message;
    localGame.push(data.message);
    console.log(localGame);
  });
  let localGame = [];
  export let name;
  export let game;

  let user = null;

  let celebrations = [];
  let nextUp;

  let messages = [];

  onMount(async () => {
    const res = await fetch(`https://localhost:6001/api/celebrations`);
    const dasd = await res.json();

    celebrations = dasd;
    nextUp = celebrations.shift();
    name = dasd[0].title;
  });

  window.onSignIn = (googleUser) => {
    console.log("googleUser", googleUser);

    var jwt = jwtDecode(googleUser.credential);

    user = {
      name: jwt.name,
      picture: jwt.picture,
      token: googleUser.credential,
    };
  };
</script>

<svelte:head>
  <script src="https://accounts.google.com/gsi/client" async defer></script>
</svelte:head>

<main>
  <div
    id="g_id_onload"
    data-client_id="1057072569039-sieh4mh26jtbbl2djnmt8o9fievuhl18.apps.googleusercontent.com"
    data-context="signin"
    data-ux_mode="popup"
    data-callback="onSignIn"
    data-auto_prompt="false"
  />

  <div class="jumbotron">
    {#if user == null}
      <div
        class="g_id_signin"
        data-type="standard"
        data-shape="rectangular"
        data-theme="outline"
        data-text="signin_with"
        data-size="medium"
        data-logo_alignment="right"
      />
    {:else}
      <img class="rounded" src="{user.picture}" alt="{user.picture}" />
      <p>{user.name}</p>
    {/if}
  </div>

  <div class="jumbotron">
    <h2>Allå, allå</h2>
    {#if nextUp != null}
      <h1 id="next-title">{nextUp.title}</h1>
      <h2>{nextUp.description}</h2>
      <h3 id="num-days">{nextUp.nextOccurrence}</h3>
    {:else}
      <p>Loading...</p>
      <h1 id="next-title">Loading...</h1>
    {/if}
  </div>

  <h3>Future:</h3>

  <div>
    <ul>
      {#each celebrations as celebration}
        <li>
          {celebration.title}
          {celebration.description}
          {celebration.nextOccurrence}
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
