<script>
	const example1 = [
		'const songs = [698, song("reach out to the truth"), 42]',
		'',
		'encounter["Normal Battles"]',
		'  music = songs',
		'end'
	];
</script>

<h1>Other Features</h1>
<p>Here is a list of other features with more niche use cases.</p>

<h2>Randomized BGM with Arrays</h2>
<pre><code
		>{example1.join('\n')}
</code></pre>
<p>
	A prior requirement of <code>random_song</code> is that all the music had to be next to each other
	in BGM IDs. This can become an issue if you want to reuse a song in a different
	<code>random_song</code>, requiring duplicate files. It also makes using default BGM with
	<code>random_song</code>
	practically impossible.
</p>
<p>
	By using an array, or list for non-programmers, you can create a setlist of specific songs that <code
		>random_song</code
	> can then randomly pick from.
</p>
