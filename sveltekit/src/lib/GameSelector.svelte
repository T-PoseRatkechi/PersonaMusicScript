<script lang="ts">
	export let value: string;
	import { allGames } from '$lib/Games';

	value = allGames[0];
</script>

<select bind:value>
	{#each allGames as game}
		<option>{game}</option>
	{/each}
</select>

<style>
	select {
		margin: 0;
	}
</style>
