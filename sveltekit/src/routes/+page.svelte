<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
</script>

<div id="header">
	<div id="bgme">BGME Framework</div>
	<div id="music-script">with Persona Music Script</div>
</div>
<h2>Introduction</h2>
<p>
	<em>BGME Framework with Persona Music Script</em> is mod+script for easily changing and adding music
	in Persona games.
</p>
<h2>Getting Started</h2>
<p>Whether you're a new or experienced modder, it's best to follow along with the guides.</p>
<p>Get started: <Link url="{base}/guides/create-mod">Creating a Music Mod</Link></p>

<style>
	#header {
		font-weight: bold;
		margin: 1rem 0;
	}

	#bgme {
		font-size: 3.5rem;
	}

	#music-script {
		font-size: 2rem;
		font-style: italic;
	}
</style>
