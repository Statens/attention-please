<script>
  import { createEventDispatcher } from 'svelte';
  import jwtDecode from "jwt-decode";

  const dispatch = createEventDispatcher();

  let user = null;

  window.handleCredentialResponse = (googleUser) => {
    console.log("Login.svelte", googleUser);

    var jwt = jwtDecode(googleUser.credential);

    user = {
      name: jwt.name,
      picture: jwt.picture,
      token: googleUser.credential,
    };
    dispatch('login', user);
  };
</script>

<svelte:head>
  <script src="https://accounts.google.com/gsi/client" async defer></script>
</svelte:head>

<div
  id="g_id_onload"
  data-client_id="1057072569039-sieh4mh26jtbbl2djnmt8o9fievuhl18.apps.googleusercontent.com"
  data-context="signin"
  data-ux_mode="popup"
  data-callback="handleCredentialResponse"
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
    <img class="rounded" src={user.picture} alt={user.picture} />
    <p>{user.name}</p>
  {/if}
</div>
