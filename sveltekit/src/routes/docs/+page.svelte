<script>
	import Toc from 'svelte-toc';
	import Collections from './Collections.svelte';
	import Constants from './Constants.svelte';
	import Functions from './Functions.svelte';
	import Encounters from './Encounters.svelte';
	import Events from './Events.svelte';
	import Floors from './Floors.svelte';
	import Global from './Global.svelte';
</script>

<div class="container">
	<div class="row">
		<Toc />
		<div class="column">
			<h1>Documentation</h1>
			<h2>General</h2>
			<Constants />
			<Collections />
			<Functions />
			<Encounters />
			<Global />
			<Floors />
			<Events />
		</div>
	</div>
</div>
