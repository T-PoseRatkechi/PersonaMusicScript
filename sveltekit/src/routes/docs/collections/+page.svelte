<script lang="ts">
	import gameCollections from './collections.json';
</script>

<h1>Collections</h1>
<p>This is a list of all available collections for each game.</p>
<h2>Special Collections</h2>
<ul>
	<li>Special Battles - Bosses, mini-bosses, etc.</li>
	<li>Normal Battles - Any battle that isn't a special battle.</li>
	<li>All - All battles (or floors).</li>
</ul>
<blockquote>Spoilers below, obviously.</blockquote>
{#each gameCollections as gameCollection}
	<h2>{gameCollection.Game}</h2>
	<div class="game-collection">
		<ul>
			{#each gameCollection.Collections as collection}
				<li>{collection}</li>
			{/each}
		</ul>
	</div>
{/each}

<style>
	.game-collection {
		filter: blur(6px);
		width: fit-content;
		transition: filter 0.5s;
	}

	.game-collection:hover {
		filter: none;
	}
</style>
