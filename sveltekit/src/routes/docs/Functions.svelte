<script lang="ts">
	interface Function {
		signature: string;
		example: string;
		description: string;
	}

	const functions: Function[] = [
		{
			signature: 'song(name)',
			example: 'song("reach out to the truth")',
			description: 'Reference a song by its name instead of its Song ID.'
		},
		{
			signature: 'random_song(minSongId, maxSongId)',
			example: 'random_song(1, 10)',
			description:
				'Randomly play a song ID from <em>minSongId</em> up to, and including, <em>maxSongId</em>.'
		},
		{
			signature: 'battle_bgm(normal, advantage[, disadvantage])',
			example: 'battle_bgm(song("time to make history"), song("reach out to the truth"))',
			description: "Plays music depending on the battle's <em>context</em>. <b>Encounters only.</b>"
		}
	];
</script>

<h3>Functions</h3>
{#each functions as func}
	<h4>{func.signature}</h4>
	<pre><code>{func.example}</code></pre>
	<p>{@html func.description}</p>
{/each}
