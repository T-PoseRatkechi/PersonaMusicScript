<script lang="ts">
	import 'milligram';
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
	import { currentGame } from '$lib/Games';
	import GameSelector from '$lib/GameSelector.svelte';
</script>

<div id="nav">
	<div class="container">
		<div class="row">
			<div id="links" class="column">
				<Link url="{base}/" text="Home" />
				<Link url="{base}/guides" text="Guides" />
				<Link url="{base}/docs" text="Documentation" />
				<Link url="{base}/docs/collections" text="Collections" />
			</div>
			<div class="column">
				<GameSelector bind:value={$currentGame} />
			</div>
		</div>
	</div>
</div>

<div class="container">
	<div class="row">
		<div class="column">
			<slot />
		</div>
	</div>
</div>

<style>
	#nav {
		border-bottom: 1px solid #606c76;
		padding: 1rem 0;
	}

	:global(#nav a + a) {
		border-left: 1px solid #606c76;
	}

	:global(#nav a) {
		padding: 0 1rem;
	}

	#links {
		display: flex;
		align-items: center;
	}

	:global(blockquote.warning) {
		border-left: solid 0.3rem rgb(255, 228, 17);
	}
</style>
